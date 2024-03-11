namespace RFRAP.Domain.Requests.Roads;

public record GetAdvertisementsByRoadNameRequest
{
    public required string RoadName { get; init; }
}