using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Requests;
using RFRAP.Domain.Services.Segments;
using RFRAP.Domain.Services.UnverifiedPoints;

namespace RFRAP.Domain.Handlers;

public class AddUnverifiedPointHandler(
    ISegmentService segmentService,
    IUnverifiedPointsService unverifiedPointsService,
    IValidator<AddUnverifiedPointRequest> validator)
{
    public async Task HandleAsync(AddUnverifiedPointRequest request, CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);
        
        var roadSegments = await segmentService.GetSegmentsByRoadNameAsync(request.RoadName, ct);
        NotFoundException.ThrowIfNull(roadSegments, nameof(roadSegments));
        
        var nearestSegment = segmentService.GetNearestSegmentByCoordinates(request.X, request.Y, roadSegments!);
        NotFoundException.ThrowIfNull(nearestSegment, nameof(nearestSegment));
        
        await unverifiedPointsService.CreateAndSavePointAsync(request.X, request.Y, nearestSegment!, ct);
    }
}