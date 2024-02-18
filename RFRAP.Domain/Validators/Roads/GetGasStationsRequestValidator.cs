using FluentValidation;
using RFRAP.Domain.Requests.Roads;

namespace RFRAP.Domain.Validators.Roads;

public class GetGasStationsRequestValidator : AbstractValidator<GetGasStationsRequest>
{
    public GetGasStationsRequestValidator()
    {
        RuleFor(request => request.RoadName)
            .NotEmpty()
            .NotNull();
        RuleFor(request => request.Coordinates)
            .NotNull();
        RuleFor(request => request.Coordinates.Latitude)
            .Must(ValidationDefaults.BeLongitude);
        RuleFor(request => request.Coordinates.Latitude)
            .Must(ValidationDefaults.BeLatitude);
    }
}