using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.Handlers.Roads;
using RFRAP.Domain.Requests.Roads;
using RFRAP.Domain.Responses;
using RFRAP.Domain.Responses.Roads;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/api/[controller]/{roadName}")]
public class RoadsController : ControllerBase
{
    [HttpPost("unverified")]
    public Task<AddUnverifiedPointResponse> AddUnverifiedPoint(
        [FromRoute] string roadName,
        [FromBody] AddUnverifiedPointRequest request,
        [FromServices] AddUnverifiedPointHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request with { RoadName = roadName }, ct);

    [HttpGet("{pointType}")]
    public Task<GetVerifiedPointsResponse> GetVerifiedPoints(
        [FromRoute] string roadName,
        [FromRoute] string pointType,
        [FromQuery] GetVerifiedPointsRequest request,
        [FromServices] GetGasStationsHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request with { RoadName = roadName, PointType = pointType }, ct);

    [HttpGet("advertisements")]
    public Task<GetAdvertisementsByRoadNameResponse> GetAdvertisementsByRoadName(
        [FromRoute] string roadName,
        [FromServices] GetAdvertisementsByRoadNameHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(new GetAdvertisementsByRoadNameRequest
        {
            RoadName = roadName
        }, ct);
}