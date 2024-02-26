using RFRAP.Domain.Models;
using RFRAP.Domain.Requests.Auth;

namespace RFRAP.Domain.Mappers;

public class LoginMapper : IMapper<LoginRequest, LoginModel>
{
    public LoginModel Map(LoginRequest from)
        => new LoginModel
        {
            Email = from.Email,
            Password = from.Password
        };
}