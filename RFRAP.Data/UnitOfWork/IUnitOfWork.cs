using RFRAP.Data.Entities;
using RFRAP.Data.Repositories;

namespace RFRAP.Data.UnitOfWork;

public interface IUnitOfWork
{
    public IRepository<UnverifiedPoint> UnverifiedPoints { get; }
    Task SaveChangesAsync(CancellationToken ct = default);
}