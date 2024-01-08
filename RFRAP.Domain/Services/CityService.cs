using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Entities;
using RFRAP.Data.Repositories;
using RFRAP.Domain.DTO;
using RFRAP.Domain.Interfaces;

namespace RFRAP.Domain.Services;

public class CityService(IRepository<City> repository, IMapper mapper) : ICityService
{
    public async Task<CityDTO?> GetCityById(Guid id)
    {
        var collection = await repository.Select();
        var city = collection.Include(c => c.Id).First(c => c.Id == id);
        
        return mapper.Map<CityDTO?>(city);
    }

    public async Task<ICollection<CityDTO>> GetAllCities()
    {
        return mapper.Map<ICollection<CityDTO>>(await repository.Select());
    }

    public async Task CreateCity(CityDTO cityDTO, CancellationToken ct = default)
    {
        var city = mapper.Map<City>(cityDTO);
        await repository.AddAsync(city, ct);
    }
}