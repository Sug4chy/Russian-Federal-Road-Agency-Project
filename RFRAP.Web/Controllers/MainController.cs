using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.DTO;
using RFRAP.Domain.Handlers;
using Serilog;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/[controller]")]
public class MainController : ControllerBase
{
    [HttpGet("getAll")]
    public IEnumerable<RoadDTO> GetAllRoads
        (/*[FromServices] MainHandler handler*/CancellationToken ct = default)
    {
        Log.Logger.Information("asdasd");
        Log.Logger.Error("asdasd");
        Log.Information("asdasd");
        Log.Error("asdasd");
        return Enumerable.Empty<RoadDTO>();
    }
}