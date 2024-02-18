using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Requests.Roads;

public record GetGasStationsRequest
{
    public required string RoadName { get; init; }
    public required PointDto Coordinates { get; init; }
}