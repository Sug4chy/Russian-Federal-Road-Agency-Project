using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Entities;
using RFRAP.Data.Repositories;

namespace RFRAP.Domain.Services.Roads;

public class RoadService(IRepository<Road> repository) : IRoadService
{
    public async Task<Road?> GetRoadByNameAsync(string roadName, CancellationToken ct = default) 
        => await repository
            .Select()
            .Include(r => r.Segments)!
            .ThenInclude(s => s.GasStations)
            .FirstOrDefaultAsync(r => r.Name == roadName, ct);

}