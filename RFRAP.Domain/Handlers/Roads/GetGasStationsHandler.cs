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
    IValidator<GetGasStationsRequest> validator,
    ISegmentService segmentService,
    IMapper<GasStation, GasStationDto> mapper)
{
    public async Task<GetGasStationsResponse> HandleAsync(GetGasStationsRequest request, 
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var roadSegments = await segmentService
            .GetSegmentsByRoadNameWithGasStationsAsync(request.RoadName, ct);
        NotFoundException.ThrowIfNull(roadSegments, RoadErrors.NoSuchRoadWithName(request.RoadName));

        var gasStations = new List<GasStation>();
        for (int i = 0; i < roadSegments!.Count; i++)
        {
            var currentSegmentGasStations = roadSegments[i].GasStations
                                            ?? Array.Empty<GasStation>();
            gasStations.AddRange(currentSegmentGasStations);
        }

        var responseGasStations = gasStations.OrderBy(gs =>
                Math.Sqrt(Math.Pow(request.Coordinates.Latitude - gs.Latitude, 2)
                          + Math.Pow(request.Coordinates.Longitude - gs.Longitude, 2)))
            .Take(10)
            .Select(mapper.Map).ToArray();
        return new GetGasStationsResponse
        {
            GasStations = responseGasStations,
            DistancesFromUser = responseGasStations
                .Select(gs => segmentService
                    .GetDistanceFromPointToUserInKm(request.Coordinates, 
                        new PointDto
                        {
                            Latitude = gs.Latitude,
                            Longitude = gs.Longitude
                        }))
                .ToArray()
        };
    }
}