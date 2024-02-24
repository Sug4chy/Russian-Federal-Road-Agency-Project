using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RFRAP.Data.Entities;
using RFRAP.Domain.ConfigurationOptions.Auth;
using RFRAP.Domain.Models;

namespace RFRAP.Domain.Services.Tokens;

public class TokenService(IOptions<JwtConfigurationOptions> options) : ITokenService
{
    private readonly JwtConfigurationOptions _jwtConfigurationOptions = options.Value;
    private const int ExpirationMinutes = 30;
    private DateTime Expiration => DateTime.UtcNow.AddMinutes(ExpirationMinutes);
    
    public string GenerateAccessToken(User user)
    {
        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            Expiration
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
            TokenExpirationTime = Expiration
        };
    }

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
            // Mb need to add Id, for other claims will read later

            /*new Claim(JwtRegisteredClaimNames.Sub, jwtSub!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),*/
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.Surname, user.Surname),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        ];

    private SigningCredentials CreateSigningCredentials()
    {
        var symmetricSecurityKey =_jwtConfigurationOptions.SymmetricSecurityKey;

        return new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(symmetricSecurityKey)
            ),
            SecurityAlgorithms.HmacSha256
        );
    }
}