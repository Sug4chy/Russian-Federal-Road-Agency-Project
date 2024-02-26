namespace RFRAP.Domain.DTOs;

public record UnverifiedPointDto
{
    public string? Description { get; init; }
    public required string Type { get; init; }
    public required PointDto Coordinates { get; init; }
}