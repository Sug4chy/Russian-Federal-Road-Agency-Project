using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.Segments;

public class SegmentService(AppDbContext context) : ISegmentService
{
    public Segment? GetNearestSegmentByCoordinates(double x, double y, IReadOnlyList<Segment> segments)
    {
        var point = new NpgsqlPoint(x, y);
        double minDistance = double.MaxValue;
        Segment? result = null;
        foreach (var segment in segments)
        {
            double distance = GetMinDistanceToSegment(point, segment);
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
        return road?.Segments.ToList();
    }

    public async Task<List<Segment>?> GetSegmentsByRoadNameWithGasStationsAsync(string roadName, CancellationToken ct = default)
    {
        var road = await context.Roads
            .Include(r => r.Segments)
            .ThenInclude(s => s.GasStations)
            .FirstOrDefaultAsync(r => r.Name == roadName, ct);
        return road?.Segments.ToList();
    }

    private static double GetMinDistanceToSegment(NpgsqlPoint point, Segment segment)
    {
        var pointAb = new NpgsqlPoint
        {
            X = segment.Point2.X - segment.Point1.X,
            Y = segment.Point2.Y - segment.Point1.Y
        };
        var pointBe = new NpgsqlPoint
        {
            X = point.X - segment.Point2.X,
            Y = point.Y - segment.Point2.Y
        };
        var pointAe = new NpgsqlPoint
        {
            X = point.X - segment.Point1.X,
            Y = point.Y - segment.Point1.Y
        };

        double abBe = pointAb.X * pointBe.X + pointAb.Y * pointBe.Y;
        double abAe = pointAb.X * pointAe.X + pointAb.Y * pointAe.Y;
        double result;
        
        if (abBe > 0) 
        {
            double y = point.Y - segment.Point2.Y;
            double x = point.X - segment.Point2.X;
            result = Math.Sqrt(x * x + y * y);
        }
        else if (abAe < 0)
        {
            double y = point.Y - segment.Point1.Y;
            double x = point.X - segment.Point1.X;
            result = Math.Sqrt(x * x + y * y);
        }
        else
        {
            double x1 = pointAb.X;
            double y1 = pointAb.Y;
            double x2 = pointAe.X;
            double y2 = pointAe.Y;
            double mod = Math.Sqrt(x1 * x1 + y1 * y1);
            result = Math.Abs(x1 * y2 - y1 * x2) / mod;
        }

        return result;
    }
}