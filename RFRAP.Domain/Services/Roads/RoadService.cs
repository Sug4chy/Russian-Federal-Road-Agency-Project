﻿using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Services.Roads;

public class RoadService(AppDbContext context) : IRoadService
{
    public Task<Road?> GetRoadByNameAsync(string roadName, CancellationToken ct = default)
        => context.Roads.FirstOrDefaultAsync(r => r.Name == roadName, ct);

    public async Task CreateAndSaveAsync(RoadDto dto, CancellationToken ct = default)
    {
        var road = new Road
        {
            Name = dto.Name
        };

        await context.Roads.AddAsync(road, ct);
        await context.SaveChangesAsync(ct);
    }
}