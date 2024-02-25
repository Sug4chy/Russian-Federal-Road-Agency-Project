using FluentValidation;
using RFRAP.Domain.Requests.Utility;

namespace RFRAP.Domain.Validators.Utility;

public class AddGasStationValidator : AbstractValidator<AddGasStationRequest>
{
    public AddGasStationValidator()
    {
        RuleFor(request => request.RoadName)
            .NotNull()
            .NotEmpty();
        RuleFor(request => request.NewVerifiedPoint)
            .NotNull();
        RuleFor(request => request.NewVerifiedPoint.Name)
            .NotEmpty()
            .NotNull();
        RuleFor(request => request.NewVerifiedPoint.Longitude)
            .Must(ValidationDefaults.BeLongitude);
        RuleFor(request => request.NewVerifiedPoint.Latitude)
            .Must(ValidationDefaults.BeLatitude);
    }
}