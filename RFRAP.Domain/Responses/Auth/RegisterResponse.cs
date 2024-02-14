namespace RFRAP.Domain.Responses.Auth;

public record RegisterResponse
{
    public required string Email { get; init; }
}