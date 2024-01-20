using RFRAP.Data.Entities;
using RFRAP.Data.Repositories;

namespace RFRAP.Data.UnitOfWork;

public class UnitOfWork(
    IRepository<UnverifiedPoint> unverifiedPoints,
    IRepository<GasStation> gasStations) : IUnitOfWork
{
    public IRepository<UnverifiedPoint> UnverifiedPoints { get; } = unverifiedPoints;
    public IRepository<GasStation> GasStations { get; } = gasStations;

    public Task SaveChangesAsync(CancellationToken ct = default)
        => unverifiedPoints.CommitChangesAsync(ct);
}