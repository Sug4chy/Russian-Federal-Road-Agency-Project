using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.Handlers;
using RFRAP.Domain.Handlers.Roads;
using RFRAP.Domain.Requests;
using RFRAP.Domain.Requests.Roads;
using RFRAP.Domain.Responses;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/api/[controller]/{roadName}")]
public class RoadsController : ControllerBase
{
    [HttpPost("unverified")]
    public Task AddUnverifiedPoint(
        [FromRoute] string roadName,
        [FromBody] AddUnverifiedPointRequest request,
        [FromServices] AddUnverifiedPointHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request with { RoadName = roadName }, ct);

    [HttpGet("gasStations")]
    public Task<GetGasStationsResponse> GetGasStations(
        [FromRoute] string roadName,
        [FromServices] GetGasStationsHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(new GetGasStationsRequest { RoadName = roadName }, ct);

    [HttpPost("gasStations")]
    public Task AddGasStation(
        [FromRoute] string roadName,
        [FromBody] AddGasStationRequest request,
        [FromServices] AddGasStationHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request with {RoadName = roadName}, ct);
}