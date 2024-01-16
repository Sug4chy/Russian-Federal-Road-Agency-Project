using AutoMapper;
using RFRAP.Domain.DTO;
using RFRAP.Domain.DTO.Responses;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Interfaces;


namespace RFRAP.Domain.Handlers;

public class GetAllRoadsHandler
    (IRoadService roadService, IMapper mapper)
{
    public async Task<RoadResponse> HandleAsync(CancellationToken ct = default)
    {
        var roads = await roadService.GetAllRoadsAsync(ct);

        if (roads.Count == 0)
            throw new RoadNotFoundException("Empty road collection, while getting all roads");
        
        return new RoadResponse
        {
            Roads = mapper.Map<RoadDTO[]>(roads)
        };
    }   
}