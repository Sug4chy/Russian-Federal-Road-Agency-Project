using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.VerifiedPoints;

public interface IVerifiedPointsService
{
    Task CreateAndSaveGasStationAsync(string name, Segment segment, double latitude, double longitude, 
        CancellationToken ct = default);
}