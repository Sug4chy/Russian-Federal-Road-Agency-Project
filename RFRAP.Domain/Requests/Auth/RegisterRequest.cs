namespace RFRAP.Domain.Requests.Auth;

public record RegisterRequest
{
    // First, second, third name? 
    public required string FirstName { get; init; }
    public required string Surname { get; init; }
    public string? Patronymic { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}