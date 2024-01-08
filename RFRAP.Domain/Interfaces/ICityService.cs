using RFRAP.Data.Entities;
using RFRAP.Domain.DTO;

namespace RFRAP.Domain.Interfaces;

public interface ICityService
{
    Task<City?> GetCityByIdAsync(Guid id, CancellationToken ct);
    Task<ICollection<City>> GetAllCitiesAsync(CancellationToken ct);
    Task CreateCityAsync(CityDTO cityDTO, CancellationToken ct);
}