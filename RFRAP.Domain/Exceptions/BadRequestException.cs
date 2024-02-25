using FluentValidation.Results;

namespace RFRAP.Domain.Exceptions;

public class BadRequestException : ExceptionBase
{
    public override int StatusCode { get; init; } = 400;

    public static void ThrowByValidationResult(ValidationResult validationResult)
    {
        if (!validationResult.IsValid)
        {
            throw new BadRequestException
            {
                Error = Errors.Error.FromValidationFailure(validationResult.Errors[0])
            };
        }
    }
}