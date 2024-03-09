using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Models;
using RFRAP.Domain.Requests.Auth;
using RFRAP.Domain.Responses.Auth;
using RFRAP.Domain.Services.Auth;
using RFRAP.Domain.Services.Users;

namespace RFRAP.Domain.Handlers.Auth;

public class RegisterHandler(
    IValidator<RegisterRequest> validator, 
    IAuthService authService,
    IUserService userService)
{
    public async Task<RegisterResponse> HandleAsync(
        RegisterRequest request, 
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var user = userService.CreateUser(request);
        var registerResult = await authService.RegisterUserAsync(
            new RegisterModel {User = user, Password = request.Password}, ct
        );

        if (!registerResult.IsSuccess)
        {
            UnauthorizedException.ThrowByError(registerResult.Error);
        }

        var tokensModel = await authService.GenerateAndSetTokensAsync(user, ct);

        return new RegisterResponse
        {
            AccessToken = tokensModel.AccessToken,
            RefreshToken = tokensModel.RefreshToken
        };
    }
}