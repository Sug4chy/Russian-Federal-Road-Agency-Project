namespace RFRAP.Domain.ConfigurationOptions.Auth;

public class JwtConfigurationOptions
{
    public const string Position = "JwtTokenSettings";

    public required string ValidIssuer { get; init; }
    public required string ValidAudience { get; init; }
    public required string SymmetricSecurityKey { get; init; }
    public required string JwtRegisteredClaimNamesSub { get; init; }
    public required int AccessTokenExpirationMinutes { get; init; }
    public required int RefreshTokenExpirationMinutes { get; init; }
}