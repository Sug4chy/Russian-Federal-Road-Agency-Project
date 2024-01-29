using FluentValidation;
using RFRAP.Domain.Requests.Files;

namespace RFRAP.Domain.Validators.Files;

public class SaveFileForPointRequestValidator : AbstractValidator<SaveFileForPointRequest>
{
    public SaveFileForPointRequestValidator()
    {
        RuleFor(request => request.File)
            .NotNull();
        RuleFor(request => request.File.FileName)
            .NotNull()
            .NotEmpty();
        RuleFor(request => request.File.ContentType)
            .NotNull()
            .NotEmpty();
        RuleFor(request => request.File.ReadStream)
            .NotNull();
    }
}