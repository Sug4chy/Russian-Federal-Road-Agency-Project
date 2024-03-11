using FluentValidation;
using RFRAP.Domain.Requests.Mobile;

namespace RFRAP.Domain.Validators.Mobile;

public class GetVerifiedPointsInRadiusRequestValidator : AbstractValidator<GetVerifiedPointsInRadiusRequest>
{
    public GetVerifiedPointsInRadiusRequestValidator()
    {
        RuleFor(request => request.Coordinates)
            .Must(ValidationDefaults.BeValidPoint);
    }
}