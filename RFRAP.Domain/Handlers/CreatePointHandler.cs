using RFRAP.Domain.DTO.Requests;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Interfaces;

namespace RFRAP.Domain.Handlers;

public class CreatePointHandler(IMarkerPointService service)
{
    public async Task HandleAsync(CreatePointRequest request, CancellationToken ct = default)
    {
        try
        {
            await service.CreateMarkerPointAsync(request, ct);
        }
        catch (ArgumentException ex)
        {
            throw new NonExistentMarkerPointType($"Couldn't find type: {request.PointType}", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new RoadNotFoundException($"Couldn't find road with id: {request.RoadId}", ex);
        }
    }
    
}