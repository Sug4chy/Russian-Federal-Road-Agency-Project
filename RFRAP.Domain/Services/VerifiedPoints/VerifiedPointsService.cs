using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Services.Distance;

namespace RFRAP.Domain.Services.VerifiedPoints;

public class VerifiedPointsService(AppDbContext context,
    IDistanceCalculator distanceCalculator) : IVerifiedPointsService
{
    public async Task CreateVerifiedPointAsync(VerifiedPointDto dto, Segment segment, CancellationToken ct = default)
    {
        var newGasStation = new VerifiedPoint
        {
            Name = dto.Name,
            SegmentId = segment.Id,
            Segment = segment,
            Longitude = dto.Longitude,
            Latitude = dto.Latitude,
            Type = dto.Type
        };

        await context.VerifiedPoints.AddAsync(newGasStation, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<VerifiedPoint>> GetVerifiedPointsInRadiusAsync(PointDto userCoordinates, 
        double radiusInKm, CancellationToken ct = default)
    {
        var allPoints = await context.VerifiedPoints.ToArrayAsync(ct);
        return allPoints.Where(vp => distanceCalculator
                .GetDistanceFromUserToPointInKm(userCoordinates, new PointDto
                {
                    Latitude = vp.Latitude,
                    Longitude = vp.Longitude
                }) <= radiusInKm);
    }
}