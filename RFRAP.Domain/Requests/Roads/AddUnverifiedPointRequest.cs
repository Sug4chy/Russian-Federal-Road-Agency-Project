using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Requests.Roads;

public record AddUnverifiedPointRequest
{
    public required UnverifiedPointDto Point { get; init; }
    public required string RoadName { get; init; }
}