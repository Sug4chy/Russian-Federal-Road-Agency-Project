using RFRAP.Data.Context;
using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.GasStations;

public class VerifiedPointsService(AppDbContext context) : IVerifiedPointsService
{
    public async Task CreateAndSaveGasStationAsync(string name, Segment segment, double latitude, double longitude,
        CancellationToken ct = default)
    {
        var newGasStation = new VerifiedPoint
        {
            Name = name,
            SegmentId = segment.Id,
            Segment = segment,
            Longitude = longitude,
            Latitude = latitude
        };

        await context.VerifiedPoints.AddAsync(newGasStation, ct);
        await context.SaveChangesAsync(ct);
    }
}