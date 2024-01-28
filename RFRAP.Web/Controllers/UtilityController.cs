using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.Handlers.Roads;
using RFRAP.Domain.Requests.Roads;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UtilityController : ControllerBase
{
    [HttpPost("{roadName}/gasStations")]
    public Task AddGasStation(
        [FromRoute] string roadName,
        [FromBody] AddGasStationRequest request,
        [FromServices] AddGasStationHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request with {RoadName = roadName}, ct);

    [HttpPost("{roadName}/segments")]
    public Task AddSegment(
        [FromRoute] string roadName,
        [FromBody] AddSegmentRequest request,
        [FromServices] AddSegmentHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request with {RoadName = roadName}, ct);
}