using FluentValidation;
using RFRAP.Domain.Requests;
using RFRAP.Domain.Requests.Roads;

namespace RFRAP.Domain.Validators;

public class AddUnverifiedPointRequestValidator : AbstractValidator<AddUnverifiedPointRequest>
{
    public AddUnverifiedPointRequestValidator()
    {
        RuleFor(request => request.RoadName).NotEmpty();
    }
}