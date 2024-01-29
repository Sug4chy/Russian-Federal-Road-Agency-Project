using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Requests.Utility;

public record AddRoadRequest
{
    public required RoadDto RoadDto { get; init; }
}