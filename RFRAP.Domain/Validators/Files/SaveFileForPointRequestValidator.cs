using FluentValidation;
using RFRAP.Domain.Requests.Files;

namespace RFRAP.Domain.Validators.Files;

public class SaveFileForPointRequestValidator : AbstractValidator<SaveFileForPointRequest>
{
    public SaveFileForPointRequestValidator()
    {
        RuleFor(request => request.UnverifiedPointId)
            .NotNull()
            .NotEqual(Guid.Empty);
        RuleFor(request => request.File)
            .Must(ValidationDefaults.BeValidFileDto);
    }
}