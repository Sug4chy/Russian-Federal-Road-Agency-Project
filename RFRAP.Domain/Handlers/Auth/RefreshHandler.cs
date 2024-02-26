using System.Security.Claims;
using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Requests.Auth;
using RFRAP.Domain.Responses.Auth;
using RFRAP.Domain.Services.Auth;
using RFRAP.Domain.Services.Tokens;
using RFRAP.Domain.Services.Users;

namespace RFRAP.Domain.Handlers.Auth;

public class RefreshHandler(
    IValidator<RefreshRequest> validator,
    ITokenService tokenService,
    IUserService userService,
    IAuthService authService)
{
    public async Task<RefreshResponse> HandleAsync(
        RefreshRequest request, 
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);
        
        var principal = tokenService
            .GetPrincipalFromExpiredToken(request.ExpiredAccessToken);
        string? username = principal.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        NotFoundException.ThrowIfNull(
            username, AuthErrors.DoesNotIncludeClaim(ClaimTypes.Email)
        );

        var user = await userService.FindUserByEmailAsync(username!, ct);
        NotFoundException.ThrowIfNull(user, UsersErrors.NoSuchUserWithEmail(username!));

        if (user!.RefreshToken != request.RefreshToken
            || user.RefreshTokenExpirationTime <= DateTime.UtcNow)
        {
            throw new ForbiddenException
            {
                Error = AuthErrors.InvalidRefreshToken
            };
        }

        var tokensModel = await authService.GenerateAndSetTokensAsync(user, ct);
        
        return new RefreshResponse
        {
            RefreshToken = tokensModel.RefreshToken,
            AccessToken = tokensModel.AccessToken
        };
    }
}