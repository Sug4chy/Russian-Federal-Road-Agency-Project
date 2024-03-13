using RFRAP.Domain.Exceptions.Errors;

namespace RFRAP.Domain.Exceptions;

public class NotFoundException : ExceptionBase
{
    public override int StatusCode { get; init; } = 404;

    public static void ThrowIfNull(object? o, Error error)
    {
        if (o is null)
        {
            throw new NotFoundException
            {
                Error = error
            };
        }
    }
}