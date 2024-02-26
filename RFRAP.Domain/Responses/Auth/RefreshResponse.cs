namespace RFRAP.Domain.Responses.Auth;

public class RefreshResponse
{
    public required string AccessToken { get; init; }
    public required string RefreshToken { get; init; }
}