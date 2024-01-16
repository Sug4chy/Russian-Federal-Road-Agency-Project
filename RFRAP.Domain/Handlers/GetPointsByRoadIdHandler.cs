using AutoMapper;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTO;
using RFRAP.Domain.DTO.Requests;
using RFRAP.Domain.DTO.Responses;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Interfaces;


namespace RFRAP.Domain.Handlers;

public class GetPointsByRoadIdHandler(IMarkerPointService pointService, IMapper mapper)
{
    public async Task<PointResponse> HandleAsync
        (PointRequest request, CancellationToken ct = default)
    {
        ICollection<MarkerPoint> collection;

        try
        {
            collection = await pointService.GetMarkerPointByRoadIdAndTypeAsync(request, ct);
        }
        catch (InvalidOperationException ex)
        {
            throw new RoadNotFoundException($"Missing road id: {request.RoadId}", ex);
        }
        catch (ArgumentException ex)
        {
            throw new NonExistentMarkerPointType($"Couldn't find type: {request.PointType}", ex);
        }
        
        return new PointResponse
        {
            Points = mapper.Map<MarkerPointDTO[]>(collection)
        };
    }
}