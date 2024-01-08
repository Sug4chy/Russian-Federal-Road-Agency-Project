using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Entities;
using RFRAP.Data.Repositories;
using RFRAP.Domain.DTO;
using RFRAP.Domain.Interfaces;

namespace RFRAP.Domain.Services;

public class MarkerPointService(IRepository<MarkerPoint> repository, IMapper mapper) : IMarkerPointService
{
    public async Task<ICollection<MarkerPointDTO>> GetAllMarkerPoints()
    {
        return mapper.Map<ICollection<MarkerPointDTO>>(await repository.Select());
    }

    public async Task<MarkerPointDTO?> GetMarkerPointById(Guid id)
    {
        var collection = await repository.Select();
        var markerPoint = collection
            .Include(p => p.Id).First(p => p.Id == id);
        return mapper.Map<MarkerPointDTO?>(markerPoint);
    }

    public async Task CreateMarkerPoint(MarkerPointDTO markerPointDTO, CancellationToken ct = default)
    {
        var markerPoint = mapper.Map<MarkerPoint>(markerPointDTO);
        await repository.AddAsync(markerPoint, ct);
        await repository.CommitChangesAsync(ct); // Надо ли?
    }
}