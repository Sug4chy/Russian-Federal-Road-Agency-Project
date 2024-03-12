using RFRAP.Data.Entities;

namespace RFRAP.Domain.DTOs;

public record MobileVerifiedPointDto
{
    public required PointDto Coordinates { get; init; }
    public required string Name { get; init; }
    public required VerifiedPointType Type { get; init; }
}