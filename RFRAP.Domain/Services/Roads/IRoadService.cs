using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Services.Roads;

public interface IRoadService
{
    Task<Road?> GetRoadByNameAsync(string roadName, CancellationToken ct = default);
    Task CreateAndSaveAsync(RoadDto road, CancellationToken ct = default);
}