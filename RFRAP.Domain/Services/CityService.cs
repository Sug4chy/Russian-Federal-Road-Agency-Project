using AutoMapper;
using RFRAP.Data.Entities;
using RFRAP.Data.Repositories;
using RFRAP.Domain.DTO;
using RFRAP.Domain.Interfaces;

namespace RFRAP.Domain.Services;

public class CityService(IRepository<City> repository, IMapper mapper) : ICityService
{
    public async Task<City?> GetCityByIdAsync(Guid id, CancellationToken ct = default)
    {
        var collection = await repository.Select();
        return collection.First(c => c.Id == id);
    }

    public async Task<ICollection<City>> GetAllCitiesAsync(CancellationToken ct = default)
    {
        var collection = await repository.Select();
        return collection.ToList();
    }

    public async Task CreateCityAsync(CityDTO cityDTO, CancellationToken ct = default)
    {
        var city = mapper.Map<City>(cityDTO);
        await repository.AddAsync(city, ct);
        await repository.CommitChangesAsync(ct);
    }
}