using FluentValidation;
using RFRAP.Domain.Requests.Roads;

namespace RFRAP.Domain.Validators.Roads;

public class AddUnverifiedPointRequestValidator : AbstractValidator<AddUnverifiedPointRequest>
{
    public AddUnverifiedPointRequestValidator()
    {
        RuleFor(request => request.RoadName)
            .NotEmpty();
        RuleFor(request => request.Point)
            .Must(ValidationDefaults.BeValidUnverifiedPointDto);
    }
}