using FluentValidation;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Validators.Manager;

public class VerifiedPointDtoValidator : AbstractValidator<VerifiedPointDto>
{
    public VerifiedPointDtoValidator()
    {
        RuleFor(vp => vp.Name)
            .NotEmpty();
        //TODO Make avaliable: " ", russian letters, numbers; prohibit everything else.
        RuleFor(vp => vp.Coordinates)
            .Must(ValidationDefaults.BeValidPoint);
        RuleFor(vp => vp.RoadName)
            .NotEmpty();
    }
}