using Microsoft.AspNetCore.Identity;
using RFRAP.Data.Entities;
using RFRAP.Domain.Requests.Auth;

namespace RFRAP.Domain.Services.Users;

public class UserService(UserManager<User> userManager) : IUserService
{
    public User CreateUser(RegisterRequest request)
        => new User
        {
            FirstName = request.FirstName, 
            Surname = request.Surname, 
            Patronymic = request.Patronymic,
            UserName = request.Email,
            Email = request.Email,
            Role = Role.Manager
        };

    // Норм или как у тебя в birthdays сделать?
    // И с ct непонятно т.к у менеджера нет такой перегрузки
    public Task<User?> FindUserByEmailAsync(string email, CancellationToken ct = default)
        => userManager.FindByEmailAsync(email);

    public Task<User?> FindUserByIdAsync(string id, CancellationToken ct = default)
        => userManager.FindByIdAsync(id);

}