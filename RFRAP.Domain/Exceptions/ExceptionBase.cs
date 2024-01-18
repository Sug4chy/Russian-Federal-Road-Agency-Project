namespace RFRAP.Domain.Exceptions;

public abstract class ExceptionBase(string message) : Exception(message)
{
    public abstract int StatusCode { get; init; }
}