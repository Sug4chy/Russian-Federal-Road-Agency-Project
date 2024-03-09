namespace RFRAP.Domain.Responses.Auth;

public record LoginResponse
{
    public required string AccessToken { get; init; }
    public required string RefreshToken { get; init; }
}