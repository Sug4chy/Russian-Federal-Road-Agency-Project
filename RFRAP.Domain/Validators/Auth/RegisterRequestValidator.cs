using FluentValidation;
using RFRAP.Domain.Requests.Auth;

namespace RFRAP.Domain.Validators.Auth;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(request => request.Name)
            .NotNull()
            .NotEmpty();
        RuleFor(request => request.Email)
            .NotNull()
            .NotEmpty();
        RuleFor(request => request.Password)
            .NotNull()
            .NotEmpty();
    }
}