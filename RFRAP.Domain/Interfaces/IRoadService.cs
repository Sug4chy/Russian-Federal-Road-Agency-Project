using RFRAP.Data.Entities;
using RFRAP.Domain.DTO;

namespace RFRAP.Domain.Interfaces;

public interface IRoadService
{
    Task<Road> GetRoadByIdAsync(Guid id, CancellationToken ct);
    Task<ICollection<Road>> GetAllRoadsAsync(CancellationToken ct);
    Task AddRoadAsync(RoadDTO roadDto, CancellationToken ct);
}