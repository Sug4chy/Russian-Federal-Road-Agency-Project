using FluentValidation;
using RFRAP.Domain.Requests.Utility;

namespace RFRAP.Domain.Validators.Utility;

public class AddGasStationValidator : AbstractValidator<AddGasStationRequest>
{
    public AddGasStationValidator()
    {
        RuleFor(request => request.RoadName)
            .NotEmpty();
        RuleFor(request => request.NewVerifiedPoint)
            .Must(ValidationDefaults.BeValidVerifiedPointDto);
    }
}