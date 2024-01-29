using FluentValidation;
using RFRAP.Domain.Requests.Utility;

namespace RFRAP.Domain.Validators.Utility;

public class AddRoadRequestValidator : AbstractValidator<AddRoadRequest>
{
    public AddRoadRequestValidator()
    {
        RuleFor(request => request.RoadDto.Name)
            .NotNull()
            .NotEmpty();
    }
}