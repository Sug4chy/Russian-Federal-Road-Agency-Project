using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Mappers;
using RFRAP.Domain.Models;
using RFRAP.Domain.Requests.Auth;
using RFRAP.Domain.Responses.Auth;
using RFRAP.Domain.Services.Auth;
using RFRAP.Domain.Services.Users;

namespace RFRAP.Domain.Handlers.Auth;

public class LoginHandler(
    IValidator<LoginRequest> validator,
    IMapper<LoginRequest, LoginModel> mapper,
    IAuthService authService,
    IUserService userService)
{
    public async Task<LoginResponse> HandleAsync(
        LoginRequest request, 
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var loginModel = mapper.Map(request);
        var authResult = await authService.LoginUserAsync(loginModel, ct);
        
        if (!authResult.IsSuccess)
        {
            UnauthorizedException.ThrowByError(authResult.Error);
        }

        var user = await userService.FindUserByEmailAsync(loginModel.Email, ct);
        NotFoundException.ThrowIfNull(
            user,
            UsersErrors.NoSuchUserWithEmail(loginModel.Email)
        );

        var tokensModel = await authService.GenerateAndSetTokensAsync(user!, ct);

        return new LoginResponse
        {
            AccessToken = tokensModel.AccessToken,
            RefreshToken = tokensModel.RefreshToken
        };
    }
}