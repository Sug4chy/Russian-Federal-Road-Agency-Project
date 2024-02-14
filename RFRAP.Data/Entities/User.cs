using Microsoft.AspNetCore.Identity;

namespace RFRAP.Data.Entities;

public class User : IdentityUser
{
    public required string Name { get; set; }
}