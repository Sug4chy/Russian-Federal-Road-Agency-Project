using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.Segments;

public interface ISegmentService
{
    Segment? GetNearestSegmentByCoordinates(double x, double y, IReadOnlyList<Segment> segments);
    Task<List<Segment>?> GetSegmentsByRoadName(string roadName, CancellationToken ct = default);
}