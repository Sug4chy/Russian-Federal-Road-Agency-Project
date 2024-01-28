using FluentValidation;
using RFRAP.Domain.Requests.Utility;

namespace RFRAP.Domain.Validators.Utility;

public class AddGasStationValidator : AbstractValidator<AddGasStationRequest>
{
    public AddGasStationValidator()
    {
        RuleFor(request => request.RoadName).NotEmpty();
        RuleFor(request => request.NewGasStation.Name)
            .NotEmpty()
            .NotNull();
        RuleFor(request => request.NewGasStation.X)
            .Must(BeLongitude);
        RuleFor(request => request.NewGasStation.Y)
            .Must(BeLatitude);
    }

    private static bool BeLongitude(double x)
        => x is >= 0D and <= 180D;

    private static bool BeLatitude(double y)
        => y is >= -90D and <= 90D;
}