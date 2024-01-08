using RFRAP.Domain.DTO;

namespace RFRAP.Domain.Interfaces;

public interface ICityService
{
    Task<CityDTO?> GetCityById(Guid id);
    Task<ICollection<CityDTO>> GetAllCities();
    Task CreateCity(CityDTO cityDTO, CancellationToken ct);
}