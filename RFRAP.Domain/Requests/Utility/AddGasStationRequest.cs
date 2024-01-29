using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Requests.Utility;

public record AddGasStationRequest
{
    public required string RoadName { get; init; }
    public required GasStationDto NewGasStation { get; init; }
}