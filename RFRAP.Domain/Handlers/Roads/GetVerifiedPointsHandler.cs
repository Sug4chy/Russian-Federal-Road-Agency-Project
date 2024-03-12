using FluentValidation;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Mappers;
using RFRAP.Domain.Requests.Roads;
using RFRAP.Domain.Responses.Roads;
using RFRAP.Domain.Services.Distance;
using RFRAP.Domain.Services.Segments;

namespace RFRAP.Domain.Handlers.Roads;

public class GetVerifiedPointsHandler(
    IValidator<GetVerifiedPointsRequest> validator,
    ISegmentService segmentService,
    IMapper<VerifiedPoint, VerifiedPointDto> mapper,
    IDistanceCalculator distanceCalculator)
{
    public async Task<GetVerifiedPointsResponse> HandleAsync(GetVerifiedPointsRequest request,
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var roadSegments = await segmentService
            .GetSegmentsByRoadNameWithVerifiedPointsAsync(request.RoadName!,
                Enum.Parse<VerifiedPointType>(request.PointType!), ct);
        NotFoundException.ThrowIfNull(roadSegments, RoadErrors.NoSuchRoadWithName(request.RoadName!));

        var verifiedPoints = new List<VerifiedPoint>();
        for (int i = 0; i < roadSegments!.Count; i++)
        {
            var currentSegmentVerifiedPoints = roadSegments[i].VerifiedPoints;
            verifiedPoints.AddRange(currentSegmentVerifiedPoints);
        }

        var responseVerifiedPoints = verifiedPoints.OrderBy(gs =>
                Math.Sqrt(Math.Pow(request.Coordinates.Latitude - gs.Latitude, 2)
                          + Math.Pow(request.Coordinates.Longitude - gs.Longitude, 2)))
            .Where(vp => distanceCalculator
                .GetDistanceFromUserToPointInKm(request.Coordinates,
                    new PointDto
                    {
                        Latitude = vp.Latitude,
                        Longitude = vp.Longitude
                    }) <= 50)
            .Take(10)
            .Select(mapper.Map)
            .ToArray();
        return new GetVerifiedPointsResponse
        {
            Points = responseVerifiedPoints,
            DistancesFromUser = responseVerifiedPoints
                .Select(vp => distanceCalculator
                    .GetDistanceFromUserToPointInKm(request.Coordinates,
                        vp.Coordinates))
                .ToArray()
        };
    }
}