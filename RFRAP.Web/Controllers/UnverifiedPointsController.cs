using Microsoft.AspNetCore.Mvc;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Services.UnverifiedPoints;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Mappers;
using RFRAP.Domain.Responses.UnverifiedPoints;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UnverifiedPointsController(
    IUnverifiedPointsService unverifiedPointsService) : ControllerBase
{
    [HttpGet]
    public async Task<GetAllPointsResponse> GetAllPoints(
        [FromServices] IMapper<UnverifiedPoint, UnverifiedPointDto> mapper, 
        CancellationToken ct = default)
    {
        var points = await unverifiedPointsService.GetUnverifiedPointsAsync(ct);
        return new GetAllPointsResponse
        {
            Points = points.Select(mapper.Map).ToArray()
        };
    }

    [HttpPut("{pointId:guid}")]
    public async Task UpdatePoint([FromRoute] Guid pointId)
    {
        
    }

    [HttpDelete("{pointId:guid}")]
    public async Task DeletePoint([FromRoute] Guid pointId)
    {
        
    }
}