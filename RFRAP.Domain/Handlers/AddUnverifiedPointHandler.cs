using RFRAP.Data.UnitOfWork;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Requests;
using RFRAP.Domain.Services.Segments;
using RFRAP.Domain.Services.UnverifiedPoints;

namespace RFRAP.Domain.Handlers;

public class AddUnverifiedPointHandler(
    ISegmentService segmentService,
    IUnverifiedService unverifiedService,
    IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(AddUnverifiedPointRequest request, CancellationToken ct = default)
    {
        //Тут должна быть валидация запроса типа
        var roadSegments = await segmentService.GetSegmentsByRoadName(request.RoadName, ct);
        NotFoundException.ThrowIfNull(roadSegments, nameof(roadSegments));
        
        var nearestSegment = segmentService.GetNearestSegmentByCoordinates(request.X, request.Y, roadSegments!);
        NotFoundException.ThrowIfNull(nearestSegment, nameof(nearestSegment));
        var point = unverifiedService.CreatePoint(request.X, request.Y, nearestSegment!);
        
        await unitOfWork.UnverifiedPoints.AddAsync(point, ct);
        await unitOfWork.SaveChangesAsync(ct);
    }
}