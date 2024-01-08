using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Entities;
using RFRAP.Data.Repositories;
using RFRAP.Domain.DTO;
using RFRAP.Domain.Interfaces;

namespace RFRAP.Domain.Services;

public class MarkerPointService(IRepository<MarkerPoint> repository, IMapper mapper) : IMarkerPointService
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

    public async Task CreateMarkerPointAsync(MarkerPointDTO markerPointDTO, CancellationToken ct = default)
    {
        var markerPoint = mapper.Map<MarkerPoint>(markerPointDTO);
        await repository.AddAsync(markerPoint, ct);
        await repository.CommitChangesAsync(ct);
    }
}