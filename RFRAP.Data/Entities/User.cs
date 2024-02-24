using Microsoft.AspNetCore.Identity;

namespace RFRAP.Data.Entities;

public class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string Surname { get; set; }
    public string? Patronymic { get; set; } 
    public Role Role { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpirationTime { get; set; }
}