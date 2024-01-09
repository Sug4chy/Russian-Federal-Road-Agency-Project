using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RFRAP.Domain.DTO;
using RFRAP.Domain.Interfaces;


namespace RFRAP.Domain.Handlers;

public class MainHandler
    (IRoadService roadService, IMapper mapper)
{
    public async Task<ICollection<RoadDTO>> GetAllRoadsAsync(CancellationToken ct = default)
    {
        var roads = await roadService.GetAllRoadsAsync(ct);
        return mapper.Map<ICollection<RoadDTO>>(roads);
    }

    /*public async Task<ICollection<MarkerPointDTO>> GetPointsByRoadAsync(Guid id, CancellationToken ct = default)
    {
        var road = await roadService.GetRoadByIdAsync(id, ct);
        return mapper.Map<RoadDTO>(road).Points;
    }

    public async Task CreatePoint(MarkerPointDTO markerPointDTO, CancellationToken ct)
    {
        var markerPoint = mapper.Map<MarkerPoint>(markerPointDTO);
        await markerPointService.CreateMarkerPointAsync(markerPoint, ct);
    }*/
}