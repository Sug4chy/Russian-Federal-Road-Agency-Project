using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Requests.Utility;

public record AddVerifiedPointRequest
{
    public required string RoadName { get; init; }
    public required VerifiedPointDto NewVerifiedPoint { get; init; }
}