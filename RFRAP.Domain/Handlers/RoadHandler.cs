using AutoMapper;
using RFRAP.Domain.DTO;
using RFRAP.Domain.DTO.Responses;
using RFRAP.Domain.Interfaces;


namespace RFRAP.Domain.Handlers;

public class RoadHandler
    (IRoadService roadService, IMapper mapper)
{
    public async Task<RoadResponse> HandleAsync(CancellationToken ct = default)
    {
        var roads = await roadService.GetAllRoadsAsync(ct);
        
        return new RoadResponse
        {
            Road = mapper.Map<RoadDTO[]>(roads)
        };
    }   
}