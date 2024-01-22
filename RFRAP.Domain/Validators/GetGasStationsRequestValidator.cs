using FluentValidation;
using RFRAP.Domain.Requests;

namespace RFRAP.Domain.Validators;

public class GetGasStationsRequestValidator : AbstractValidator<GetGasStationsRequest>
{
    public GetGasStationsRequestValidator()
    {
        RuleFor(request => request.RoadName)
            .NotEmpty()
            .NotNull();
    }
}