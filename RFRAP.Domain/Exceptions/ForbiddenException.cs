using Microsoft.AspNetCore.Http;

namespace RFRAP.Domain.Exceptions;

public class ForbiddenException : ExceptionBase
{
    public override int StatusCode { get; init; } = StatusCodes.Status403Forbidden;
}