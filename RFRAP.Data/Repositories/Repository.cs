﻿using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Context;
using RFRAP.Data.Interfaces;

namespace RFRAP.Data.Repositories;

public class Repository<TEntity>(AppDbContext context) : IRepository<TEntity> 
    where TEntity : class
{
    private DbSet<TEntity> Set => context.Set<TEntity>();

    public Task<IQueryable<TEntity>> Select()
        => Task.FromResult(Set.AsQueryable());

    public async Task AddAsync(TEntity entity, 
        CancellationToken ct = default)
        => await Set.AddAsync(entity, ct);

    public Task Update(TEntity entity)
    {
        Set.Update(entity);
        return Task.CompletedTask;
    }

    public Task Remove(TEntity entity)
    {
        Set.Remove(entity);
        return Task.CompletedTask;
    }

    public Task CommitChangesAsync(CancellationToken ct = default)
        => context.SaveChangesAsync(ct);
}