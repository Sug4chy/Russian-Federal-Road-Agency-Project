﻿using RFRAP.Data.Extensions;
using RFRAP.Domain.Mappings;
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

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddControllers();
        
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Debug()
            .CreateLogger();

        services.AddSingleton<ErrorHandlingMiddleware>();
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
    }
}