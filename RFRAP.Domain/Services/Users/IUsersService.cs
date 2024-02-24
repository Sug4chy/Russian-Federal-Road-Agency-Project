using RFRAP.Data.Entities;
using RFRAP.Domain.Requests.Auth;

namespace RFRAP.Domain.Services.Users;

public interface IUsersService
{
    Task<User> CreateUserAsync(RegisterRequest request, CancellationToken ct);
}