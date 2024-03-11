using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Requests.Roads;
using RFRAP.Domain.Responses;
using RFRAP.Domain.Responses.Roads;
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
        NotFoundException.ThrowIfNull(roadSegments, RoadErrors.NoSuchRoadWithName(request.RoadName));

        var nearestSegment = segmentService.GetNearestSegmentByCoordinates(request.Point.Coordinates,
            roadSegments!);

        var newPoint = await unverifiedPointsService
            .CreateAndSavePointAsync(request.Point,
                nearestSegment, ct);
        return new AddUnverifiedPointResponse
        {
            AddedPointId = newPoint.Id
        };
    }
}