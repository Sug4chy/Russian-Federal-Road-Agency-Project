namespace RFRAP.Web.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next(context);
        // try
        // {
        //     await next(context);
        // }
        // catch (Exception e)
        // {
        //     switch (e)
        //     {
        //         
        //     }
        // }
    }
}