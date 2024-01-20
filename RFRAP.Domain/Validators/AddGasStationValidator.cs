using FluentValidation;
using RFRAP.Domain.Requests;

namespace RFRAP.Domain.Validators;

public class AddGasStationValidator : AbstractValidator<AddGasStationRequest>
{
    public AddGasStationValidator()
    {
        RuleFor(request => request.RoadName).NotEmpty();
        RuleFor(request => request.NewGasStation.Name)
            .NotEmpty()
            .NotNull();
    }
}