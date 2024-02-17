using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Services.UnverifiedPoints;

public interface IUnverifiedPointsService
{
    Task<UnverifiedPoint> CreateAndSavePointAsync(
        UnverifiedPointDto pointDto, Segment segment, CancellationToken ct = default);

    Task<UnverifiedPoint?> GetPointByIdAsync(Guid pointId, CancellationToken ct = default);
}