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
        RuleFor(request => request.NewGasStation)
            .NotNull();
        RuleFor(request => request.NewGasStation.Name)
            .NotEmpty()
            .NotNull();
        RuleFor(request => request.NewGasStation.Longitude)
            .Must(ValidationDefaults.BeLongitude);
        RuleFor(request => request.NewGasStation.Latitude)
            .Must(ValidationDefaults.BeLatitude);
    }
}