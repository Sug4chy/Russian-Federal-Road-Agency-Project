using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Requests.Utility;
using RFRAP.Domain.Services.Roads;
using RFRAP.Domain.Services.Segments;
using RFRAP.Domain.Services.VerifiedPoints;

namespace RFRAP.Domain.Handlers.Utility;

public class AddVerifiedPointHandler(
    IValidator<AddVerifiedPointRequest> validator,
    ISegmentService segmentService,
    IVerifiedPointsService verifiedPointsService,
    IRoadService roadService)
{
    public async Task HandleAsync(AddVerifiedPointRequest request, CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var segments = await segmentService.GetSegmentsByRoadNameAsync(request.RoadName, ct);
        NotFoundException.ThrowIfNull(segments, RoadErrors.NoSuchRoadWithName(request.RoadName));

        var road = await roadService.GetRoadByNameAsync(request.RoadName, ct);
        NotFoundException.ThrowIfNull(road, RoadErrors.NoSuchRoadWithName(request.RoadName));

        var nearestSegment = segments is null ? null : 
            segmentService.GetNearestSegmentByCoordinates(request.NewVerifiedPoint.Coordinates, segments);

        await verifiedPointsService.CreateVerifiedPointAsync(request.NewVerifiedPoint, nearestSegment, road!, ct);
    }
}