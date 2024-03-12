using Microsoft.AspNetCore.Identity;
using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class User : IdentityUser, IAuditableEntity
{
    public required string FirstName { get; set; }
    public required string Surname { get; set; }
    public string? Patronymic { get; set; } 
    public Role Role { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpirationTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastlyEditedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}