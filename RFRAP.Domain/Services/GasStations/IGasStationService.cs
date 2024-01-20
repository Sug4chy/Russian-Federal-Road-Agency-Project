using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.GasStations;

public interface IGasStationService
{
    GasStation CreateGasStation(string name, Segment segment, double x, double y);
}