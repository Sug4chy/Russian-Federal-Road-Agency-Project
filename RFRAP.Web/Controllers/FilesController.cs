using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.Handlers.Files;
using RFRAP.Domain.Requests.Files;
using RFRAP.Web.Extensions;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class FilesController : ControllerBase
{
    [HttpPost("unverified/{pointId}")]
    public Task SaveFileForPoint(
        [FromForm] IFormFile formFile,
        [FromRoute] Guid pointId,
        [FromServices] SaveFileForPointHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(new SaveFileForPointRequest
        {
            File = formFile.ToFileDto(),
            UnverifiedPointId = pointId
        }, ct);
}