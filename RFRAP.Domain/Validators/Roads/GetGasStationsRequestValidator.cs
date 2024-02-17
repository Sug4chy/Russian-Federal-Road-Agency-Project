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
        RuleFor(request => request.Longitude)
            .Must(ValidationDefaults.BeLongitude);
        RuleFor(request => request.Latitude)
            .Must(ValidationDefaults.BeLatitude);
    }
}