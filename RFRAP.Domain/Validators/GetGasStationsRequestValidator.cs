using FluentValidation;
using RFRAP.Domain.Requests.Roads;

namespace RFRAP.Domain.Validators;

public class GetGasStationsRequestValidator : AbstractValidator<GetGasStationsRequest>
{
    public GetGasStationsRequestValidator()
    {
        RuleFor(request => request.RoadName)
            .NotEmpty()
            .NotNull();
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