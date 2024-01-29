using FluentValidation;
using RFRAP.Domain.Requests.Roads;

namespace RFRAP.Domain.Validators.Roads;

public class AddUnverifiedPointRequestValidator : AbstractValidator<AddUnverifiedPointRequest>
{
    public AddUnverifiedPointRequestValidator()
    {
        RuleFor(request => request.RoadName)
            .NotEmpty();
        RuleFor(request => request.X)
            .Must(BeLongitude);
        RuleFor(request => request.Y)
            .Must(BeLatitude);
    }
    
    private static bool BeLongitude(double x)
        => x is >= 0D and <= 180D;

    private static bool BeLatitude(double y)
        => y is >= -90D and <= 90D;
}