using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Responses.Roads;

public record GetVerifiedPointsResponse
{
    public required VerifiedPointDto[] Points { get; init; }
    public required double[] DistancesFromUser { get; init; }
}