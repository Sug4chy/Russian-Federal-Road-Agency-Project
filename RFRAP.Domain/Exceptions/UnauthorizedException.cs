using Microsoft.AspNetCore.Http;
using RFRAP.Domain.Results;

namespace RFRAP.Domain.Exceptions;

public class UnauthorizedException(string message = "") : ExceptionBase(message)
{
    public override int StatusCode { get; init; } = StatusCodes.Status401Unauthorized;

    public static void ThrowByError(Error error)
    {
        throw new UnauthorizedException {Error = error};
    }
}