using NpgsqlTypes;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.GasStations;

public class GasStationService(AppDbContext context) : IGasStationService
{
    public async Task CreateAndSaveGasStationAsync(string name, Segment segment, double x, double y,
        CancellationToken ct = default)
    {
        var newGasStation = new GasStation
        {
            Name = name,
            SegmentId = segment.Id,
            Segment = segment,
            Coordinates = new NpgsqlPoint(x, y)
        };

        await context.GasStations.AddAsync(newGasStation, ct);
        await context.SaveChangesAsync(ct);
    }
}