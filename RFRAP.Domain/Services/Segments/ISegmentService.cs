using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.Segments;

public interface ISegmentService
{
    Segment? GetNearestSegmentByCoordinates(double x, double y, IReadOnlyList<Segment> segments);
    Task<List<Segment>?> GetSegmentsByRoadNameAsync(string roadName, CancellationToken ct = default);
    Task<List<Segment>?> GetSegmentsByRoadNameWithGasStationsAsync(
        string roadName, CancellationToken ct = default);
}