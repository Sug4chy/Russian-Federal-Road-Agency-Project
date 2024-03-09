using RFRAP.Data.Entities;
using RFRAP.Domain.Requests.Auth;

namespace RFRAP.Domain.Services.Users;

public interface IUserService
{
    User CreateUser(RegisterRequest request);
    Task<User?> FindUserByEmailAsync(string email, CancellationToken ct = default);
    Task<User?> FindUserByIdAsync(string id, CancellationToken ct = default);
}