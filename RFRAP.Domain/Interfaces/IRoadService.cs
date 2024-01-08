using RFRAP.Domain.DTO;

namespace RFRAP.Domain.Interfaces;

public interface IRoadService
{
    Task<RoadDTO> GetRoadById(Guid id);
    Task<ICollection<RoadDTO>> GetAllRoads();
}