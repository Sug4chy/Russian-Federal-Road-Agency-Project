using FluentValidation;

namespace RFRAP.Domain.Validators;

public class GetGasStationsRequestValidator : AbstractValidator<string>
{
    public GetGasStationsRequestValidator()
    {
        RuleFor(request => request)
            .NotEmpty()
            .NotNull();
    }
}