using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Services.UnverifiedPoints;

public class UnverifiedPointsService(AppDbContext context) : IUnverifiedPointsService
{
    public async Task<UnverifiedPoint> CreateAndSavePointAsync(UnverifiedPointDto pointDto, Segment segment,
        CancellationToken ct = default)
    {
        var newPoint = new UnverifiedPoint
        {
            IsVerified = false,
            Longitude = pointDto.Coordinates.Longitude,
            Latitude = pointDto.Coordinates.Latitude,
            SegmentId = segment.Id,
            Segment = segment,
            Type = Enum.Parse<UnverifiedPointType>(pointDto.Type),
            Description = pointDto.Description
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