using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Entities;
using RFRAP.Data.Repositories;
using RFRAP.Domain.Interfaces;
using Serilog;

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

    public async Task<ICollection<MarkerPoint>> GetMarkerPointByRoadIdAsync
        (Guid id, string pointType, CancellationToken ct = default)
    {
        var collection = await roadRepository.Select();
        
        var road = collection.Include(r => r.Points).First(r => r.Id == id);
        Log.Warning($"Road found: {road.Id}");
        return road.Points ?? Array.Empty<MarkerPoint>();
    }

    public async Task CreateMarkerPointAsync(MarkerPoint markerPoint, CancellationToken ct = default)
    {
        await repository.AddAsync(markerPoint, ct);
        await repository.CommitChangesAsync(ct);
    }
}