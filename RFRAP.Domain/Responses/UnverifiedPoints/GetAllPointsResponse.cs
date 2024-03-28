using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Responses.UnverifiedPoints;

public record GetAllPointsResponse
{
    public required UnverifiedPointDto[] Points { get; init; }
}