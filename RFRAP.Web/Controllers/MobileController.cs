using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.Handlers.Mobile;
using RFRAP.Domain.Requests.Mobile;
using RFRAP.Domain.Responses.Mobile;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class MobileController : ControllerBase
{
    [HttpGet("verifiedPoints")]
    public Task<GetVerifiedPointsInRadiusResponse> GetVerifiedPointsInRadius(
        [FromQuery] GetVerifiedPointsInRadiusRequest request,
        [FromServices] GetVerifiedPointsInRadiusHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request, ct);

}