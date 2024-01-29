using RFRAP.Web.Middlewares;

namespace RFRAP.Web.Extensions;

public static class MiddlewareExtensions
{
    public static IServiceCollection AddErrorHandling(this IServiceCollection services)
        => services.AddSingleton<ErrorHandlingMiddleware>();

    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        => app.UseMiddleware<ErrorHandlingMiddleware>();
}