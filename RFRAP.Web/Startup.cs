﻿using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Context;
using RFRAP.Data.Extensions;
using RFRAP.Domain.ConfigurationOptions.Files;
using RFRAP.Domain.Extensions;
using RFRAP.Web.Extensions;
using Serilog;

namespace RFRAP.Web;

public class Startup(IConfiguration config)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<UploadFilesOptions>(
            config.GetSection(UploadFilesOptions.Position));
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddDbContextWithInterceptors(config.GetConnectionString("DefaultConnection") ?? "");
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
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        
        app.UseErrorHandling();

        app.UseRouting();
        
        app.UseEndpoints(endpointRouteBuilder => endpointRouteBuilder.MapControllers());
    }
}