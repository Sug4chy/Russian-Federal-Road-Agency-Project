using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.Roads;

public class RoadService(AppDbContext context) : IRoadService
{
    public Task<Road?> GetRoadByNameAsync(string roadName, CancellationToken ct = default)
        => context.Roads.FirstOrDefaultAsync(r => r.Name == roadName, ct);

}