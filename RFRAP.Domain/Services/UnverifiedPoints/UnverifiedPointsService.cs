using NpgsqlTypes;
using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.UnverifiedPoints;

public class UnverifiedPointsService : IUnverifiedPointsService
{
    public UnverifiedPoint CreatePoint(double x, double y, Segment segment)
        => new()
        {
            IsVerified = false,
            Coordinates = new NpgsqlPoint(x, y),
            SegmentId = segment.Id,
            Segment = segment
        };
}