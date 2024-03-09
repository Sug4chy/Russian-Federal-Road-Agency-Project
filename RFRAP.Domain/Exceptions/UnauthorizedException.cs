using Microsoft.AspNetCore.Http;
using RFRAP.Domain.Exceptions.Errors;

namespace RFRAP.Domain.Exceptions;

public class UnauthorizedException : ExceptionBase
{
    public override int StatusCode { get; init; } = StatusCodes.Status401Unauthorized;

    public static void ThrowByError(Error error)
    {
        throw new UnauthorizedException {Error = error};
    }
}