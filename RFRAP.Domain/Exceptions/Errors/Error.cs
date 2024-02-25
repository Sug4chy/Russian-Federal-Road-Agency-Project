using FluentValidation.Results;

namespace RFRAP.Domain.Exceptions.Errors;

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static Error FromValidationFailure(ValidationFailure failure)
        => new("ValidationError", failure.ErrorMessage);
}