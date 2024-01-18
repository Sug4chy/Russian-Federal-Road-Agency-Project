using FluentValidation;
using RFRAP.Data.UnitOfWork;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Requests;
using RFRAP.Domain.Services.Segments;
using RFRAP.Domain.Services.UnverifiedPoints;

namespace RFRAP.Domain.Handlers;

public class AddUnverifiedPointHandler(
    ISegmentService segmentService,
    IUnverifiedPointsService unverifiedPointsService,
    IUnitOfWork unitOfWork,
    IValidator<AddUnverifiedPointRequest> validator)
{
    public async Task HandleAsync(AddUnverifiedPointRequest request, CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);
        
        var roadSegments = await segmentService.GetSegmentsByRoadName(request.RoadName, ct);
        NotFoundException.ThrowIfNull(roadSegments, nameof(roadSegments));
        
        var nearestSegment = segmentService.GetNearestSegmentByCoordinates(request.X, request.Y, roadSegments!);
        NotFoundException.ThrowIfNull(nearestSegment, nameof(nearestSegment));
        
        var point = unverifiedPointsService.CreatePoint(request.X, request.Y, nearestSegment!);
        await unitOfWork.UnverifiedPoints.AddAsync(point, ct);
        await unitOfWork.SaveChangesAsync(ct);
    }
}