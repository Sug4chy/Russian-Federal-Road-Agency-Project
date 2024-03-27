using FluentValidation;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Validators.Manager;

public class ManagerVerifiedPointDtoValidator : AbstractValidator<ManagerVerifiedPointDto>
{
    public ManagerVerifiedPointDtoValidator()
    {
        RuleFor(vp => vp.Id)
            .NotEmpty();
        RuleFor(vp => vp.Name)
            .NotEmpty();
        //TODO Make avaliable: " ", russian letters, numbers; prohibit everything else.
        RuleFor(vp => vp.Coordinates)
            .Must(ValidationDefaults.BeValidPoint);
        RuleFor(vp => vp.Type)
            .IsInEnum();
        RuleFor(vp => vp.RoadName)
            .NotEmpty();
    }
}