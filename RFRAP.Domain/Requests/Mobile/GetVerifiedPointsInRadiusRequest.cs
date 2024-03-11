using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Requests.Mobile;

public record GetVerifiedPointsInRadiusRequest
{
    public required PointDto Coordinates { get; init; }
}