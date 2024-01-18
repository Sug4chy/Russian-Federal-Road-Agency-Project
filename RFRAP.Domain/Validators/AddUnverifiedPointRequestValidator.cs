using FluentValidation;
using RFRAP.Domain.Requests;

namespace RFRAP.Domain.Validators;

public class AddUnverifiedPointRequestValidator : AbstractValidator<AddUnverifiedPointRequest>
{
    public AddUnverifiedPointRequestValidator()
    {
        RuleFor(request => request.RoadName).NotEmpty();
    }
}