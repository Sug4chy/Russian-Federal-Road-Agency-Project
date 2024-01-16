namespace RFRAP.Domain.Exceptions;

public class NonExistentMarkerPointType : CustomExceptionBase
{
    public override int StatusCode => 404;

    public NonExistentMarkerPointType()
    {
    }

    public NonExistentMarkerPointType(string message) : base(message)
    {
        
    }

    public NonExistentMarkerPointType(string message, Exception ex)
        : base(message, ex)
    {
        
    }
}