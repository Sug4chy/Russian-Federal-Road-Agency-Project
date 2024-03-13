using FluentValidation;
using RFRAP.Domain.Requests.Roads;

namespace RFRAP.Domain.Validators.Roads;

public class GetVerifiedPointsRequestValidator : AbstractValidator<GetVerifiedPointsRequest>
{
    public GetVerifiedPointsRequestValidator()
    {
        RuleFor(request => request.RoadName)
            .NotNull()
            .NotEmpty();
        RuleFor(request => request.PointType)
            .NotNull()
            .NotEmpty()
            .Must(ValidationDefaults.BeVerifiedPointType);
        RuleFor(request => request.Coordinates)
            .Must(ValidationDefaults.BeValidPoint);
    }
}