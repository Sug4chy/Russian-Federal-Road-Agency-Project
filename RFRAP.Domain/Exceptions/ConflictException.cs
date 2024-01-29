namespace RFRAP.Domain.Exceptions;

public class ConflictException(string message) : ExceptionBase(message)
{
    public override int StatusCode { get; init; } = 409;

    public static void ThrowIfParamNotNull(object? o, string objName, string paramName)
    {
        if (o is not null)
        {
            throw new ConflictException($"{paramName} field in {objName} is not null");
        }
    }
}