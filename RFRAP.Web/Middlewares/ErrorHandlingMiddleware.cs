using System.Net.Mime;
using System.Text.Json;
using RFRAP.Domain.Exceptions;
using RFRAP.Web.Models;

namespace RFRAP.Web.Middlewares;

public class ErrorHandlingMiddleware(
    ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            string newContent;
            switch (ex)
            {
                case ExceptionBase exceptionBase:
                    logger.LogError($"{exceptionBase.Error.Description} error occurred");
                    context.Response.StatusCode = exceptionBase.StatusCode;
                    newContent = JsonSerializer.Serialize(new ServerErrorModel
                    {
                        ErrorCode = exceptionBase.Error.Code,
                        ErrorMessage = exceptionBase.Error.Description
                    });
                    break;
                default:
                    logger.LogError($"{ex.Message} error occurred");
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    newContent = JsonSerializer.Serialize(new ServerErrorModel
                    {
                        ErrorCode = ex.GetType().Name,
                        ErrorMessage = ex.Message
                    });
                    break;
            }

            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(newContent);
        }
    }
}