namespace RFRAP.Domain.Exceptions;

public class NotFoundException(string message = "") : ExceptionBase(message)
{
    public override int StatusCode { get; init; } = 404;

    public static void ThrowIfNull(object? o, string argumentName)
    {
        if (o is null)
        {
            throw new NotFoundException($"{argumentName} was null");
        }
    }
}