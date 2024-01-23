using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RFRAP.Data.Context;
using RFRAP.Data.Context.Interceptors;

namespace RFRAP.Data.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection 
        AddDbContextWithInterceptors(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            var updateAuditableInterceptor = serviceProvider
                .GetRequiredService<UpdateAuditableEntitiesInterceptor>();
            options.UseNpgsql(connectionString)
                .AddInterceptors(updateAuditableInterceptor);
        });
        return services;
    }
}