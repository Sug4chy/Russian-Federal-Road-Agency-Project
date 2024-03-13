using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Responses.Mobile;

public record GetVerifiedPointsInRadiusResponse
{
    public required MobileVerifiedPointDto[] Points { get; init; }
}