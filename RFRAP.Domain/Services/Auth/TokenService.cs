using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.Auth;

public class TokenService(IConfigurationRoot root)
{
    private const int ExpirationMinutes = 30;
    private IConfigurationSection _jwtSettings = root.GetSection("JwtTokenSettings");
    
    public string CreateToken(User user)
    {
        var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);
        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            expiration
        );
        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }

    private JwtSecurityToken CreateJwtToken(
        List<Claim> claims,
        SigningCredentials credentials,
        DateTime expiration)
        => new JwtSecurityToken(
            _jwtSettings["ValidIssuer"],
            _jwtSettings["ValidAudience"],
            claims,
            expires: expiration,
            signingCredentials: credentials);

    private List<Claim> CreateClaims(User user)
    {
        var jwtSub = _jwtSettings["JwtRegisteredClaimNamesSub"];

        return
        [
            new Claim(JwtRegisteredClaimNames.Sub, jwtSub!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
        ];
    }

    private SigningCredentials CreateSigningCredentials()
    {
        var symmetricSecurityKey = _jwtSettings["SymmetricSecurityKey"];

        return new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(symmetricSecurityKey)
            ),
            SecurityAlgorithms.HmacSha256
        );
    }
}