using AutoMapper;
using RFRAP.Domain.DTO;
using RFRAP.Domain.DTO.Responses;
using RFRAP.Domain.Interfaces;


namespace RFRAP.Domain.Handlers;

public class PointHandler(IMarkerPointService pointService, IMapper mapper)
{
    public async Task<PointResponse> HandleAsync
        (Guid roadId, string pointType, CancellationToken ct = default)
    {
        var collection = await pointService.GetMarkerPointByRoadIdAsync(roadId, pointType, ct);

        return new PointResponse
        {
            Point = mapper.Map<MarkerPointDTO[]>(collection)
        };
    }
}