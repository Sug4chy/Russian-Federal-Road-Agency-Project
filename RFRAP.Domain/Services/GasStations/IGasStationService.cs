using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.GasStations;

public interface IGasStationService
{
    Task CreateAndSaveGasStationAsync(string name, Segment segment, double latitude, double longitude, 
        CancellationToken ct = default);
}