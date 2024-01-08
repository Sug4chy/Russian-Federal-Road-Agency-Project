using RFRAP.Domain.DTO;

namespace RFRAP.Domain.Interfaces;

public interface IMarkerPointService
{
    Task<ICollection<MarkerPointDTO>> GetAllMarkerPoints();
    Task<MarkerPointDTO?> GetMarkerPointById(Guid id);
    Task CreateMarkerPoint(MarkerPointDTO markerPoint, CancellationToken ct);
}