﻿namespace RFRAP.Data.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IQueryable<TEntity>> Select();
    Task AddAsync(TEntity entity, CancellationToken ct = default);
    Task Update(TEntity entity);
    Task Remove(TEntity entity);
    Task CommitChangesAsync(CancellationToken ct = default);
}