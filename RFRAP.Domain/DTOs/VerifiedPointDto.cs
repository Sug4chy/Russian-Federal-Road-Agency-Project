using RFRAP.Data.Entities;

namespace RFRAP.Domain.DTOs;

public record VerifiedPointDto
{
    public required string Name { get; init; }
    public required PointDto Coordinates { get; init; }
    public required VerifiedPointType Type { get; init; }
}