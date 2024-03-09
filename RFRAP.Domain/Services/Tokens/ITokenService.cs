using System.Security.Claims;
using RFRAP.Data.Entities;
using RFRAP.Domain.Models;

namespace RFRAP.Domain.Services.Tokens;

public interface ITokenService
{
    public string GenerateAccessToken(User user);
    public RefreshTokenModel GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    Claim[] GetClaimsFromJwt(string token);
}