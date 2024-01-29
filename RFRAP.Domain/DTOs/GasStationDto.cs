namespace RFRAP.Domain.DTOs;

public record GasStationDto
{
    public required string Name { get; init; }
    public required double X { get; init; }
    public required double Y { get; init; }
}