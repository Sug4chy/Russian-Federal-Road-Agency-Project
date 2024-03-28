using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Services.Distance;

namespace RFRAP.Domain.Services.VerifiedPoints;

public class VerifiedPointsService(
    AppDbContext context,
    IDistanceCalculator distanceCalculator) 
    : IVerifiedPointsService
{
    public async Task CreateVerifiedPointAsync(VerifiedPointDto dto, Segment? segment, Road road,
        CancellationToken ct = default)
    {
        var verifiedPoint = new VerifiedPoint
        {
            Name = dto.Name,
            Longitude = dto.Coordinates.Longitude,
            Latitude = dto.Coordinates.Latitude,
            Type = dto.Type,
            RoadId = road.Id,
            Road = road
        };

        if (segment is not null)
        {
            verifiedPoint.SegmentId = segment.Id;
            verifiedPoint.Segment = segment;
        }

        await context.VerifiedPoints.AddAsync(verifiedPoint, ct);
        await context.SaveChangesAsync(ct);
    }

    public Task<VerifiedPoint?> GetVerifiedPointAsync(Guid id, CancellationToken ct = default)
    {
        return context.VerifiedPoints
            .Include(vp => vp.Road)
            .SingleOrDefaultAsync(vp => vp.Id == id, ct);
    }

    public async Task EditVerifiedPointAsync(
        VerifiedPoint point, 
        VerifiedPointDto dto,
        Road road,
        Segment? segment, 
        CancellationToken ct = default)
    {
        point.Name = dto.Name;
        point.Longitude = dto.Coordinates.Longitude;
        point.Latitude = dto.Coordinates.Latitude;
        point.Type = dto.Type;
        point.RoadId = road.Id;
        point.Road = road;
        
        if(segment is not null)
        {
            point.SegmentId = segment.Id;
            point.Segment = segment;
        }

        await Task.Run(() => context.Update(point), ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task DeleteVerifiedPointAsync(VerifiedPoint verifiedPoint, CancellationToken ct = default)
    {
        await Task.Run(() => context.VerifiedPoints.Remove(verifiedPoint), ct);
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