using RFRAP.Data.Extensions;
using RFRAP.Domain.Extensions;
using RFRAP.Web.Extensions;
using RFRAP.Web.Middlewares;
using Serilog;

namespace RFRAP.Web;

public class Startup(IConfiguration config)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddDbContextWithInterceptors(config.GetConnectionString("DefaultConnection") ?? "");
        services.AddGenericRepository();
        services.AddUnitOfWork();
        services.AddValidators();
        services.AddDomainServices();
        services.AddMappers();
        services.AddHandlers();

        services.AddControllers();
        
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Debug()
            .CreateLogger();

        services.AddErrorHandling();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseMiddleware<ErrorHandlingMiddleware>();
        
        app.UseEndpoints(endpointRouteBuilder => endpointRouteBuilder.MapControllers());

        app.UseErrorHandling();
    }
}