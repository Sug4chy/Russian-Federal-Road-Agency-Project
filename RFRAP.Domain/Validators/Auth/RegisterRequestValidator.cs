using FluentValidation;
using RFRAP.Domain.Requests.Auth;

namespace RFRAP.Domain.Validators.Auth;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(request => request.Email).NotEmpty();
        RuleFor(request => request.FirstName).NotEmpty();
        RuleFor(request => request.Surname).NotEmpty();
        RuleFor(request => request.Patronymic)
            .NotEmpty()
            .When(request => request.Patronymic is not null);
        RuleFor(request => request.Password)
            .NotEmpty()
            .Length(10, 120)
            .Must(password => password.Any(char.IsDigit))
            .Must(password => password.Any(char.IsUpper));
            /*.Must(password => password.Any(char.IsSymbol));
             * Add more
             */
    }
}