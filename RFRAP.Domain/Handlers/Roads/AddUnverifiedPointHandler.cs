using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Requests.Roads;
using RFRAP.Domain.Responses;
using RFRAP.Domain.Services.Segments;
using RFRAP.Domain.Services.UnverifiedPoints;

namespace RFRAP.Domain.Handlers.Roads;

public class AddUnverifiedPointHandler(
    ISegmentService segmentService,
    IUnverifiedPointsService unverifiedPointsService,
    IValidator<AddUnverifiedPointRequest> validator)
{
    public async Task<AddUnverifiedPointResponse> HandleAsync(
        AddUnverifiedPointRequest request, CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);
        
        var roadSegments = await segmentService.GetSegmentsByRoadNameAsync(request.RoadName, ct);
        NotFoundException.ThrowIfNull(roadSegments, nameof(roadSegments));
        
        var nearestSegment = segmentService.GetNearestSegmentByCoordinates(request.X, request.Y, roadSegments!);
        NotFoundException.ThrowIfNull(nearestSegment, nameof(nearestSegment));
        
        var newPoint = await unverifiedPointsService
            .CreateAndSavePointAsync(request.X, request.Y, nearestSegment!, ct);
        return new AddUnverifiedPointResponse
        {
            AddedPointId = newPoint.Id
        };
    }
}