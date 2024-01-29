namespace RFRAP.Domain.DTOs;

public record SegmentDto
{
    public required PointDto Point1 { get; init; }
    public required PointDto Point2 { get; init; }
}