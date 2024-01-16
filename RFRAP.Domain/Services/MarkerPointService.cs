using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Entities;
using RFRAP.Data.Repositories;
using RFRAP.Domain.DTO.Requests;
using RFRAP.Domain.Interfaces;

namespace RFRAP.Domain.Services;

public class MarkerPointService
    (IRepository<MarkerPoint> repository, IRepository<Road> roadRepository) : IMarkerPointService
{
    public async Task<ICollection<MarkerPoint>> GetAllMarkerPointsAsync(CancellationToken ct = default)
    {
        var collection = await repository.Select();
        return collection.ToList();
    }

    public async Task<MarkerPoint?> GetMarkerPointByIdAsync(Guid id, CancellationToken ct = default)
    {
        var collection = await repository.Select();
        return collection.First(p => p.Id == id);
    }

    public async Task<ICollection<MarkerPoint>> GetMarkerPointByRoadIdAndTypeAsync
        (PointRequest request, CancellationToken ct = default)
    {
        
        var collection = await roadRepository.Select();

        var points = collection
            .Include(r => r.Points)
            .First(r => r.Id == request.RoadId)
            .Points;

        if (request.PointType is not null)
        {
            var type = Enum.Parse<MarkerType>(request.PointType);
            points = points?.Where(p => p.Type == type).ToArray();
        }
        
        return points ?? Array.Empty<MarkerPoint>();
    }

    public async Task CreateMarkerPointAsync(CreatePointRequest request, CancellationToken ct = default)
    {
        var roads = await roadRepository.Select();
        var roadId = roads.First(r => r.Id == request.RoadId).Id;
        
        var markerPoint = new MarkerPoint
        {
            Id = Guid.NewGuid(),
            Coordinates = new Point(request.X, request.Y),
            RoadId = roadId,
            Type = Enum.Parse<MarkerType>(request.PointType)
        };
        
        await repository.AddAsync(markerPoint, ct);
        await repository.CommitChangesAsync(ct);
    }
}