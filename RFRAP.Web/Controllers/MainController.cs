using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.DTO;
using RFRAP.Domain.Handlers;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/[controller]")]
public class MainController : ControllerBase
{
    [HttpGet("getAll")]
    public async Task<IEnumerable<RoadDTO>> GetAllRoads
        ([FromServices] MainHandler handler, CancellationToken ct = default)
    {
        return await handler.GetAllRoadsAsync(ct);
    }
}