namespace RFRAP.Domain.Requests.Auth;

public record RefreshRequest
{
    public required string ExpiredAccessToken { get; init; }
    public required string RefreshToken { get; init; }
}