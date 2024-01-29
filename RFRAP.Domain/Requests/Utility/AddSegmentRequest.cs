using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Requests.Utility;

public record AddSegmentRequest
{
    public required SegmentDto Segment { get; init; }
    public string? RoadName { get; init; }
}