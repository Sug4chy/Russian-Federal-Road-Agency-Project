using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Services.Segments;

namespace RFRAP.Domain.Services.VerifiedPoints;

public class VerifiedPointsService(AppDbContext context,
    ISegmentService segmentService) : IVerifiedPointsService
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

    public async Task<IEnumerable<VerifiedPoint>> GetVerifiedPointsInRadiusAsync(PointDto userCoordinates, double radiusInKm,
        CancellationToken ct = default)
    {
        var allPoints = await context.VerifiedPoints.ToArrayAsync(ct);
        return allPoints.Where(vp => segmentService
                .GetDistanceFromPointToUserInKm(userCoordinates, new PointDto
                {
                    Latitude = vp.Latitude,
                    Longitude = vp.Longitude
                }) <= radiusInKm);
    }
}