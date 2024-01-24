using FluentValidation;
using RFRAP.Domain.Requests;
using RFRAP.Domain.Requests.Roads;

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