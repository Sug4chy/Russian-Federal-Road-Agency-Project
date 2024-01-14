using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.DTO.Responses;
using RFRAP.Domain.Handlers;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/[controller]")]
public class MainController : ControllerBase
{
    [HttpGet("getAll")]
    public Task<RoadResponse> GetAllRoads
        ([FromServices] RoadHandler handler, CancellationToken ct = default) 
        => handler.HandleAsync(ct);
    
    // 0 идей пока что с poinType enum-ом делать
    [HttpGet("{roadId}/{pointType}")]
    public Task<PointResponse> GetPoints
        ([FromServices] PointHandler handler, Guid roadId, string pointType, CancellationToken ct = default)
        => handler.HandleAsync(roadId, pointType, ct);
}