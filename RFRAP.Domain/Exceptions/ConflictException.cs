namespace RFRAP.Domain.Exceptions;

public class ConflictException(string message = "") : ExceptionBase(message)
{
    public override int StatusCode { get; init; } = 409;

    public static void ThrowIfNotNull(object? o, string objName, string paramName)
    {
        if (o is not null)
        {
            throw new ConflictException($"{objName} with that value of field " +
                                        $"{paramName} already exists");
        }
    }
}