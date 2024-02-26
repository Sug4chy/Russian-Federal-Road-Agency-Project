using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using RFRAP.Data.Entities;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Services.Users;

namespace RFRAP.Domain.Accessors;

public class CurrentUserAccessor(
    IHttpContextAccessor accessor,
    IUserService userService) : ICurrentUserAccessor
{
    private readonly HttpContext _context = accessor.HttpContext!;
    
    public async Task<User> GetCurrentUserAsync(CancellationToken ct = default)
    {
        string userId = _context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                        throw new UnauthorizedException
                        {
                            Error = AuthErrors.DoesNotIncludeClaim(ClaimTypes.NameIdentifier)
                        };

        var currentUser = await userService.FindUserByIdAsync(userId, ct) ??
                          throw new UnauthorizedException
                          {
                              Error = AuthErrors.InvalidAccessToken
                          };

        return currentUser;
    }
}