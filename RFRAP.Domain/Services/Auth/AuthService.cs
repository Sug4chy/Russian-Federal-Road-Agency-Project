using Microsoft.AspNetCore.Identity;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Models;
using RFRAP.Domain.Results;
using RFRAP.Domain.Services.Tokens;

namespace RFRAP.Domain.Services.Auth;

public class AuthService(
    UserManager<User> userManager, 
    SignInManager<User> signInManager,
    ITokenService tokenService,
    AppDbContext context) : IAuthService
{
    public async Task<Result> RegisterUserAsync(
        RegisterModel registerModel, 
        CancellationToken ct = default)
    {
        var creationResult = await userManager.CreateAsync(
            registerModel.User, registerModel.Password
        );

        if (!creationResult.Succeeded)
        {
            return Result.FromIdentityError(
                creationResult.Errors.First()
            );
        }

        //var roleResult = await userManager.AddToRoleAsync(registerModel.User, "Administrator");

        await signInManager.SignInAsync(
            registerModel.User,
            false
        );

        return Result.Success();
    }
    
    public async Task<Result> LoginUserAsync(LoginModel model, CancellationToken ct = default)
    {
        var result = await signInManager.PasswordSignInAsync(
            model.Email,
            model.Password,
            false, 
            false
        );

        return result.Succeeded ? Result.Success() : Result.Failure(AuthErrors.SignInError);
    }

    public async Task<Result> LogoutUserAsync(User user, CancellationToken ct = default)
    {
        user.RefreshToken = null;
        user.RefreshTokenExpirationTime = null;
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }

    public async Task<AuthTokensModel> GenerateAndSetTokensAsync(User user, CancellationToken ct = default)
    {
        var refreshTokenModel = tokenService.GenerateRefreshToken();
        
        user.RefreshToken = refreshTokenModel.Token;
        user.RefreshTokenExpirationTime = refreshTokenModel.TokenExpirationTime;
        string accessToken = tokenService.GenerateAccessToken(user);
        await context.SaveChangesAsync(ct);

        return new AuthTokensModel {AccessToken = accessToken, RefreshToken = refreshTokenModel.Token};
    }
}