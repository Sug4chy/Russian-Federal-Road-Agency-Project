namespace RFRAP.Domain.DTOs;

public record PointDto
{
    public required double X { get; init; }
    public required double Y { get; init; }
}