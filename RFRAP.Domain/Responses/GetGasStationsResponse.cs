using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Responses;

public record GetGasStationsResponse
{
    public required GasStationDto[] GasStations { get; init; } 
        = Array.Empty<GasStationDto>();
    public required double[] DistancesFromUser { get; init; }
}