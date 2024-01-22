namespace RFRAP.Domain.Requests;

public record GetGasStationsRequest
{
    public string? RoadName { get; init; }
}