using RFRAP.Data.Entities;

namespace RFRAP.Domain.Interfaces;

public interface IMarkerPointService
{
    Task<ICollection<MarkerPoint>> GetAllMarkerPointsAsync(CancellationToken ct);
    Task<MarkerPoint?> GetMarkerPointByIdAsync(Guid id, CancellationToken ct);

    Task<ICollection<MarkerPoint>> GetMarkerPointByRoadIdAsync
        (Guid id, string pointType, CancellationToken ct = default);
    Task CreateMarkerPointAsync(MarkerPoint markerPoint, CancellationToken ct);
}