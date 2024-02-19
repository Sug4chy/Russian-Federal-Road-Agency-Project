using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Requests.Roads;

public record GetVerifiedPointsRequest
{
    public string? RoadName { get; init; }
    public required PointDto Coordinates { get; init; }
    public string? PointType { get; init; }
}