namespace RFRAP.Domain.Requests.Roads;

public record GetGasStationsRequest
{
    public string? RoadName { get; init; }
    public required double Longitude { get; init; }
    public required double Latitude { get; init; }
}