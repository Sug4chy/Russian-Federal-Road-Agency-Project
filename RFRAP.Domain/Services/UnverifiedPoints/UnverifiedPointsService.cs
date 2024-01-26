using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.UnverifiedPoints;

public class UnverifiedPointsService(AppDbContext context) : IUnverifiedPointsService
{
    public async Task<UnverifiedPoint> CreateAndSavePointAsync(double x, double y, Segment segment, CancellationToken ct = default)
    {
        var newPoint = new UnverifiedPoint
        {
            IsVerified = false,
            Coordinates = new NpgsqlPoint(x, y),
            SegmentId = segment.Id,
            Segment = segment
        };

        await context.UnverifiedPoints.AddAsync(newPoint, ct);
        await context.SaveChangesAsync(ct);
        return newPoint;
    }

    public Task<UnverifiedPoint?> GetPointByIdAsync(Guid pointId, CancellationToken ct = default)
        => context.UnverifiedPoints
            .Include(up => up.File)
            .FirstOrDefaultAsync(up => up.Id == pointId, ct);
}