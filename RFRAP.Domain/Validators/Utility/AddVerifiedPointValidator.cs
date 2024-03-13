using FluentValidation;
using RFRAP.Domain.Requests.Utility;

namespace RFRAP.Domain.Validators.Utility;

public class AddVerifiedPointValidator : AbstractValidator<AddVerifiedPointRequest>
{
    public AddVerifiedPointValidator()
    {
        RuleFor(request => request.RoadName)
            .NotEmpty();
        RuleFor(request => request.NewVerifiedPoint)
            .Must(ValidationDefaults.BeValidVerifiedPointDto);
    }
}