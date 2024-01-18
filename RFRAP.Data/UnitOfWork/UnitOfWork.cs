using RFRAP.Data.Entities;
using RFRAP.Data.Repositories;

namespace RFRAP.Data.UnitOfWork;

public class UnitOfWork(IRepository<UnverifiedPoint> unverifiedPoints) : IUnitOfWork
{
    public IRepository<UnverifiedPoint> UnverifiedPoints { get; } = unverifiedPoints;

    public Task SaveChangesAsync(CancellationToken ct = default)
        => unverifiedPoints.CommitChangesAsync(ct);
}