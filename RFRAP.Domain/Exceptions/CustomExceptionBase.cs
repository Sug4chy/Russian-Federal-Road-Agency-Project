namespace RFRAP.Domain.Exceptions;

public abstract class CustomExceptionBase : Exception
{
    public abstract int StatusCode { get; }

    protected CustomExceptionBase()
    {
    }

    protected CustomExceptionBase(string message) : base(message)
    {
        
    }

    protected CustomExceptionBase(string message, Exception innerException)
        : base(message, innerException)
    {
        
    }
}