namespace RFRAP.Domain.DTOs;

public record GasStationDto
{
    public required string Name { get; init; }
    public required double Longitude { get; init; }
    public required double Latitude { get; init; }
}