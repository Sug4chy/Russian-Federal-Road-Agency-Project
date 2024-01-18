﻿using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.Handlers;
using RFRAP.Domain.Requests;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RoadsController : ControllerBase
{
    [HttpPost("{roadName}/unverified")]
    public Task AddUnverifiedPoint(
        [FromRoute] string roadName,
        [FromBody] AddUnverifiedPointRequest request,
        [FromServices] AddUnverifiedPointHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request with { RoadName = roadName }, ct);
}