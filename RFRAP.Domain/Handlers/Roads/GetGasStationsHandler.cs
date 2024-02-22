using FluentValidation;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Mappers;
using RFRAP.Domain.Requests.Roads;
using RFRAP.Domain.Responses;
using RFRAP.Domain.Services.Segments;

namespace RFRAP.Domain.Handlers.Roads;

public class GetGasStationsHandler(
    IValidator<GetVerifiedPointsRequest> validator,
    ISegmentService segmentService,
    IMapper<VerifiedPoint, VerifiedPointDto> mapper)
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
            .Take(10)
            .Select(mapper.Map).ToArray();
        return new GetVerifiedPointsResponse
        {
            Points = responseVerifiedPoints,
            DistancesFromUser = responseVerifiedPoints
                .Select(vp => segmentService
                    .GetDistanceFromPointToUserInKm(request.Coordinates, 
                        new PointDto
                        {
                            Latitude = vp.Latitude,
                            Longitude = vp.Longitude
                        }))
                .ToArray()
        };
    }
}