namespace RFRAP.Domain.DTO.Requests;

public record PointRequest
{
    public required Guid RoadId { get; init; }
    public string? PointType { get; init; }
}