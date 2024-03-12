using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Services.Distance;

namespace RFRAP.Domain.Services.Segments;

public class SegmentService(
    AppDbContext context,
    IDistanceCalculator distanceCalculator
) : ISegmentService
{
    public Segment GetNearestSegmentByCoordinates(PointDto point, IEnumerable<Segment> segments)
    {
        double minDistance = double.MaxValue;
        Segment result = null!;
        foreach (var segment in segments)
        {
            double distance = distanceCalculator.GetDistanceToSegment(point, segment);
            if (distance >= minDistance)
            {
                continue;
            }

            minDistance = distance;
            result = segment;
        }

        return result;
    }

    public async Task<List<Segment>?>
        GetSegmentsByRoadNameAsync(string roadName, CancellationToken ct = default)
    {
        var road = await context.Roads
            .Include(r => r.Segments)
            .FirstOrDefaultAsync(r => r.Name == roadName, ct);
        return road?.Segments?.ToList();
    }

    public async Task<List<Segment>?> GetSegmentsByRoadNameWithVerifiedPointsAsync(string roadName,
        VerifiedPointType pointType, CancellationToken ct = default)
    {
        var road = await context.Roads
            .Include(r => r.Segments)!
            .ThenInclude(s => s.VerifiedPoints.Where(vp => vp.Type == pointType))
            .FirstOrDefaultAsync(r => r.Name == roadName, ct);
        return road?.Segments?.ToList();
    }

    public async Task CreateAndSaveSegmentAsync(SegmentDto dto, Road road, CancellationToken ct = default)
    {
        var newSegment = new Segment
        {
            Longitude1 = dto.Point1.Longitude,
            Latitude1 = dto.Point1.Latitude,
            Longitude2 = dto.Point2.Longitude,
            Latitude2 = dto.Point2.Latitude,
            Road = road,
            RoadId = road.Id
        };
        await context.Segments.AddAsync(newSegment, ct);
        await context.SaveChangesAsync(ct);
    }
}