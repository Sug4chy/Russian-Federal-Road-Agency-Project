using FluentValidation;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Mappers;
using RFRAP.Domain.Responses;
using RFRAP.Domain.Services.Roads;

namespace RFRAP.Domain.Handlers;

public class GetGasStationsHandler(
    IValidator<string> validator, 
    IRoadService roadService, 
    IMapper<GasStation, GasStationDto> mapper)
{
    public async Task<GetGasStationsResponse> HandleAsync(string roadName, CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(roadName, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var road = await roadService.GetRoadByNameAsync(roadName, ct);
        NotFoundException.ThrowIfNull(road, nameof(road));

        var gasStations = new List<GasStation>();

        foreach (var segment in road.Segments)
        {
            gasStations.AddRange(segment.GasStations);
        }

        return new GetGasStationsResponse
        {
            GasStations = gasStations.Select(mapper.Map).ToArray()
        };
    }
}