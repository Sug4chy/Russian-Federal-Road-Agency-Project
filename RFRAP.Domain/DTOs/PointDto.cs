namespace RFRAP.Domain.DTOs;

public record PointDto
{
    public required double Longitude { get; init; }
    public required double Latitude { get; init; }
}