using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.DTO.Requests;
using RFRAP.Domain.DTO.Responses;
using RFRAP.Domain.Handlers;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/[controller]")]
public class ApiController : ControllerBase
{
    [HttpGet("getAll")]
    public Task<RoadResponse> GetAllRoadsAsync
        ([FromServices] GetAllRoadsHandler handler, CancellationToken ct = default)
        => handler.HandleAsync(ct);
    
    [HttpGet("{roadId}/{pointType?}")]
    public Task<PointResponse> GetPointsAsync
    ([FromServices] GetPointsByRoadIdHandler handler,
        [FromRoute] PointRequest request, CancellationToken ct = default)
        => handler.HandleAsync(request, ct);

    //Для меня: AntiForgeryToken, DisableModelBinding
    [HttpPost("{roadId}")]
    public Task CreatePointAsync([FromServices] CreatePointHandler handler,
        [FromBody, FromRoute] CreatePointRequest request, CancellationToken ct) 
        => handler.HandleAsync(request, ct);
}