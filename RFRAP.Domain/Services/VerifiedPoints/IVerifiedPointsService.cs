using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Services.VerifiedPoints;

public interface IVerifiedPointsService
{
    Task CreateVerifiedPointAsync(VerifiedPointDto dto, Segment segment,
        CancellationToken ct = default);

    Task<IEnumerable<VerifiedPoint>> GetVerifiedPointsInRadiusAsync(PointDto userCoordinates, double radiusInKm,
        CancellationToken ct = default);
}