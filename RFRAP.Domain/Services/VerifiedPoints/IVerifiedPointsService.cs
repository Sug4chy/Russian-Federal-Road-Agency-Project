using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Services.VerifiedPoints;

public interface IVerifiedPointsService
{
    Task CreateVerifiedPointAsync(VerifiedPointDto dto, Segment? segment, Road road,
        CancellationToken ct = default);
    Task<VerifiedPoint?> GetVerifiedPointAsync(Guid id, CancellationToken ct = default);
    Task EditVerifiedPointAsync(VerifiedPoint point, VerifiedPointDto dto, Road road, Segment? segment, 
        CancellationToken ct = default);
    Task DeleteVerifiedPointAsync(VerifiedPoint verifiedPoint, CancellationToken ct);
    Task<IEnumerable<VerifiedPoint>> GetVerifiedPointsInRadiusAsync(PointDto userCoordinates, double radiusInKm,
        CancellationToken ct = default);
}