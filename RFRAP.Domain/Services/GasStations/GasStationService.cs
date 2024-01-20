using NpgsqlTypes;
using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.GasStations;

public class GasStationService : IGasStationService
{
    public GasStation CreateGasStation(string name, Segment segment, double x, double y)
        => new()
        {
            Name = name,
            SegmentId = segment.Id,
            Segment = segment,
            Coordinates = new NpgsqlPoint(x, y)
        };
}