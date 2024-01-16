using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Entities;
using RFRAP.Data.Repositories;
using RFRAP.Domain.DTO;
using RFRAP.Domain.Interfaces;

namespace RFRAP.Domain.Services;

public class RoadService(IRepository<Road> repository, IMapper mapper) : IRoadService
{
    public async Task<Road> GetRoadByIdAsync(Guid id, CancellationToken ct = default)
    {
        var collection = await repository.Select();
        return collection.First(r => r.Id == id);
    }

    public async Task<ICollection<Road>> GetAllRoadsAsync(CancellationToken ct = default)
    {
        var collection = await repository.Select();
        
        return collection
            .Include(r => r.SourceCity)
            .Include(r => r.DestCity)
            .ToList();
    }

    public async Task AddRoadAsync(RoadDTO roadDto, CancellationToken ct = default)
    {
        var road = mapper.Map<Road>(roadDto);
        await repository.AddAsync(road, ct);
        await repository.CommitChangesAsync(ct);
    }
}