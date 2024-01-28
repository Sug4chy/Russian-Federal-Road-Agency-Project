using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.Roads;

public interface IRoadService
{
    Task<Road?> GetRoadByNameAsync(string roadName, CancellationToken ct = default);
}