using RFRAP.Domain.Accessors;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Services.Auth;

namespace RFRAP.Domain.Handlers.Auth;

public class LogoutHandler(
    ICurrentUserAccessor userAccessor,
    IAuthService authService)
{
    public async Task HandleAsync(CancellationToken ct = default)
    {
        var currentUser = await userAccessor.GetCurrentUserAsync(ct);
        var logoutResult = await authService.LogoutUserAsync(currentUser, ct);
        
        if (!logoutResult.IsSuccess)
        {
            UnauthorizedException.ThrowByError(logoutResult.Error);
        }
    }
}