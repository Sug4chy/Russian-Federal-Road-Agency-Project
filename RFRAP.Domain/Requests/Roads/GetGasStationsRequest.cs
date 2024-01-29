namespace RFRAP.Domain.Requests.Roads;

public record GetGasStationsRequest
{
    public string? RoadName { get; init; }
    public required double X { get; init; }
    public required double Y { get; init; }
}