namespace RFRAP.Domain.Requests.Roads;

public record GetGasStationsRequest
{
    public string? RoadName { get; init; }
}