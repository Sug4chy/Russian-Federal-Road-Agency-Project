using RFRAP.Domain.Exceptions.Errors;

namespace RFRAP.Domain.Exceptions;

public class ConflictException : ExceptionBase
{
    public override int StatusCode { get; init; } = 409;

    public static void ThrowIfNotNull(object? o, Error error)
    {
        if (o is not null)
        {
            throw new ConflictException
            {
                Error = error
            };
        }
    }
}