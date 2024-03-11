using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Services.VerifiedPoints;

public interface IVerifiedPointsService
{
    Task CreateAndSaveGasStationAsync(string name, Segment segment, double latitude, double longitude, 
        CancellationToken ct = default);

    Task<IEnumerable<VerifiedPoint>> GetVerifiedPointsInRadiusAsync(PointDto userCoordinates, double radiusInKm,
        CancellationToken ct = default);
}