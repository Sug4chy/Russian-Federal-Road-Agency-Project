using RFRAP.Data.Entities;
using RFRAP.Domain.DTO.Requests;

namespace RFRAP.Domain.Interfaces;

public interface IMarkerPointService
{
    Task<ICollection<MarkerPoint>> GetAllMarkerPointsAsync(CancellationToken ct);
    Task<MarkerPoint?> GetMarkerPointByIdAsync(Guid id, CancellationToken ct);
    Task<ICollection<MarkerPoint>> GetMarkerPointByRoadIdAndTypeAsync
        (PointRequest request, CancellationToken ct = default);
    Task CreateMarkerPointAsync(CreatePointRequest markerPoint, CancellationToken ct);
}