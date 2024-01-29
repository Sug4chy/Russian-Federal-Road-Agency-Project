namespace RFRAP.Domain.Requests.Roads;

public record AddUnverifiedPointRequest
{
    public required double X { get; init; }
    public required double Y { get; init; }
    public required string RoadName { get; init; }
}