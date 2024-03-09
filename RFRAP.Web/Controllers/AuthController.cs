using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFRAP.Domain.Handlers.Auth;
using RFRAP.Domain.Requests.Auth;
using RFRAP.Domain.Responses.Auth;

namespace RFRAP.Web.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    public Task<RegisterResponse> Register(
        [FromBody] RegisterRequest request, 
        [FromServices] RegisterHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request, ct);

    [HttpPost("login")]
    public Task<LoginResponse> Login(
        [FromBody] LoginRequest request,
        [FromServices] LoginHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request, ct);

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("logout")]
    public Task Logout(
        [FromServices] LogoutHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(ct);

    [HttpPost("refresh")]
    public Task<RefreshResponse> Refresh(
        [FromBody] RefreshRequest request,
        [FromServices] RefreshHandler handler,
        CancellationToken ct = default)
        => handler.HandleAsync(request, ct);
}