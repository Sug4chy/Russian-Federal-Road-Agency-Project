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
            .NotNull();
        RuleFor(request => request.Point.Type)
            .NotNull()
            .NotEmpty()
            .Must(ValidationDefaults.BeUnverifiedPointType);
        RuleFor(request => request.Point.Coordinates)
            .NotNull();
        RuleFor(request => request.Point.Coordinates.Longitude)
            .Must(ValidationDefaults.BeLongitude);
        RuleFor(request => request.Point.Coordinates.Latitude)
            .Must(ValidationDefaults.BeLatitude);
    }
}