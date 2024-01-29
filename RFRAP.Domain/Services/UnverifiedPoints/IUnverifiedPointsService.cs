using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.UnverifiedPoints;

public interface IUnverifiedPointsService
{
    Task<UnverifiedPoint> CreateAndSavePointAsync(
        double x, double y, Segment segment, CancellationToken ct = default);

    Task<UnverifiedPoint?> GetPointByIdAsync(Guid pointId, CancellationToken ct = default);
}