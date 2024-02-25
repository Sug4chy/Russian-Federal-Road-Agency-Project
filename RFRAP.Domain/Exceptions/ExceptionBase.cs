using RFRAP.Domain.Exceptions.Errors;

namespace RFRAP.Domain.Exceptions;

public abstract class ExceptionBase : Exception
{
    public abstract int StatusCode { get; init; }
    public required Error Error { get; init; }
}