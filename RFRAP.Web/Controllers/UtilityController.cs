using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.Handlers.Utility;
using RFRAP.Domain.Requests.Utility;

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
        => handler.HandleAsync(request with { RoadName = roadName }, ct);
}