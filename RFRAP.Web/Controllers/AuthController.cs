using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.Handlers.Auth;
using RFRAP.Domain.Requests.Auth;
using RFRAP.Domain.Responses.Auth;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    public Task<RegisterResponse> Register(
        [FromBody] RegisterRequest request, 
        [FromServices] RegisterHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request, ct);
}