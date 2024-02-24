using RFRAP.Data.Entities;
using RFRAP.Domain.Requests.Auth;

namespace RFRAP.Domain.Services.Users;

public class UsersService : IUsersService
{
    public Task<User> CreateUserAsync(RegisterRequest request, CancellationToken ct)
        => Task.FromResult(new User
        {
            FirstName = request.FirstName, 
            Surname = request.Surname, 
            Patronymic = request.Patronymic,
            UserName = request.Email,
            Email = request.Email,
            Role = Role.Manager
        });
}