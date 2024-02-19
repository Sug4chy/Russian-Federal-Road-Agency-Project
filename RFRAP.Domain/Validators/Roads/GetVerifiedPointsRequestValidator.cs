using FluentValidation;
using RFRAP.Domain.Requests.Roads;

namespace RFRAP.Domain.Validators.Roads;

public class GetVerifiedPointsRequestValidator : AbstractValidator<GetVerifiedPointsRequest>
{
    public GetVerifiedPointsRequestValidator()
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
        RuleFor(request => request.PointType)
            .NotNull()
            .NotEmpty()
            .Must(ValidationDefaults.BeVerifiedPointType);
    }
}