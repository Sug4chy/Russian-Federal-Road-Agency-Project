namespace RFRAP.Domain.Requests.Auth;

public record RegisterRequest
{
    // First, second, third name? 
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}