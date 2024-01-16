namespace RFRAP.Domain.DTO.Requests;

public record CreatePointRequest
{
    public required Guid RoadId { get; init; }
    public required string PointType { get; init; }
    public required double X { get; init; }
    public required double Y { get; init; }
    public byte[]? PointFileContent { get; init; }
}