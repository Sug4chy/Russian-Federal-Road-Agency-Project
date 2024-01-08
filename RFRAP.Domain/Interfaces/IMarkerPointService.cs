using RFRAP.Data.Entities;
using RFRAP.Domain.DTO;

namespace RFRAP.Domain.Interfaces;

public interface IMarkerPointService
{
    Task<ICollection<MarkerPoint>> GetAllMarkerPointsAsync(CancellationToken ct);
    Task<MarkerPoint?> GetMarkerPointByIdAsync(Guid id, CancellationToken ct);
    Task CreateMarkerPointAsync(MarkerPointDTO markerPoint, CancellationToken ct);
}