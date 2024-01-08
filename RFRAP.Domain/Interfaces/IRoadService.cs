using RFRAP.Data.Entities;

namespace RFRAP.Domain.Interfaces;

public interface IRoadService
{
    Task<Road> GetRoadByIdAsync(Guid id, CancellationToken ct);
    Task<ICollection<Road>> GetAllRoadsAsync(CancellationToken ct);
}