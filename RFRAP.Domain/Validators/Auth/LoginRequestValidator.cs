using FluentValidation;
using RFRAP.Domain.Requests.Auth;

namespace RFRAP.Domain.Validators.Auth;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(request => request.Email).NotEmpty();
        RuleFor(request => request.Password).NotEmpty();
    }
}