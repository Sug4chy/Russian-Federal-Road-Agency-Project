using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FluentValidation.Results;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RFRAP.Data.Entities;
using RFRAP.Domain.ConfigurationOptions.Auth;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Models;
using ValidationFailure = FluentValidation.Results.ValidationFailure;

namespace RFRAP.Domain.Services.Tokens;

public class TokenService(IOptions<JwtConfigurationOptions> options) : ITokenService
{
    private readonly JwtConfigurationOptions _jwtConfigurationOptions = options.Value;
    
    private SymmetricSecurityKey SymmetricSecurityKey 
        => new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtConfigurationOptions.SymmetricSecurityKey)
        );
    
    private DateTime AccessTokenExpiration 
        => DateTime.UtcNow.AddMinutes(
            _jwtConfigurationOptions.AccessTokenExpirationMinutes
        );

    private DateTime RefreshTokenExpiration 
        => DateTime.UtcNow.AddDays(_jwtConfigurationOptions.RefreshTokenExpirationDays);

    public string GenerateAccessToken(User user)
    {
        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            AccessTokenExpiration
        );
        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }

    public RefreshTokenModel GenerateRefreshToken()
    {
        byte[] randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return new RefreshTokenModel()
        {
            Token = Convert.ToBase64String(randomNumber),
            TokenExpirationTime = RefreshTokenExpiration
        };
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = _jwtConfigurationOptions.ValidIssuer,
            ValidateAudience = true,
            ValidAudience = _jwtConfigurationOptions.ValidAudience,
            ValidateLifetime = true,
            IssuerSigningKey = SymmetricSecurityKey,
            ValidateIssuerSigningKey = true
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(
            token,
            tokenValidationParameters,
            out var securityToken
        );

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            BadRequestException.ThrowByValidationResult(new ValidationResult
            {
                Errors =
                [
                    new ValidationFailure
                    {
                        ErrorCode = "InvalidToken",
                        ErrorMessage = "Invalid access token"
                    }
                ]
            });
        }

        return principal;
    }

    public Claim[] GetClaimsFromJwt(string token)
        => new JwtSecurityTokenHandler()
            .ReadJwtToken(token)
            .Claims
            .ToArray();

    private JwtSecurityToken CreateJwtToken(
        List<Claim> claims,
        SigningCredentials credentials,
        DateTime expiration)
        => new JwtSecurityToken(
            _jwtConfigurationOptions.ValidIssuer,
            _jwtConfigurationOptions.ValidAudience,
            claims,
            expires: expiration,
            signingCredentials: credentials
        );

    private List<Claim> CreateClaims(User user)
        =>
        [
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.Surname, user.Surname),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        ];

    private SigningCredentials CreateSigningCredentials()
        => new SigningCredentials(
            SymmetricSecurityKey,
            SecurityAlgorithms.HmacSha256
        );
}