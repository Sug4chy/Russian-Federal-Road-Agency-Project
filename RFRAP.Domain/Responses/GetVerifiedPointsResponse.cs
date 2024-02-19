using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Responses;

public record GetVerifiedPointsResponse
{
    public required VerifiedPointDto[] Points { get; init; } 
        = Array.Empty<VerifiedPointDto>();
    public required double[] DistancesFromUser { get; init; }
}