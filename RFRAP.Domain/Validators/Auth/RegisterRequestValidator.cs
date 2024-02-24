using FluentValidation;
using RFRAP.Domain.Requests.Auth;

namespace RFRAP.Domain.Validators.Auth;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(request => request.Email)
            .NotNull()
            .NotEmpty();
        RuleFor(request => request.FirstName)
            .NotNull()
            .NotEmpty();
        RuleFor(request => request.Surname)
            .NotNull()
            .NotEmpty();
        RuleFor(request => request.Password)
            .NotNull()
            .NotEmpty()
            .Length(10, 120)
            .Must(password => password.Any(char.IsDigit))
            .Must(password => password.Any(char.IsUpper));
            /*.Must(password => password.Any(char.IsSymbol));
             * Add more
             */
    }
}