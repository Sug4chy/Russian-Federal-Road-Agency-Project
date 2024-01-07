using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RFRAP.Data.Context;
using RFRAP.Data.Context.Interceptors;
using RFRAP.Data.Repositories;

namespace RFRAP.Data.Extensions;

public static class DependencyInjection
{
    public static void AddDbContextWithInterceptors(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            var updateAuditableInterceptor = serviceProvider
                .GetRequiredService<UpdateAuditableEntitiesInterceptor>();
            options.UseNpgsql(connectionString)
                .AddInterceptors(updateAuditableInterceptor);
        });
    }

    public static void AddGenericRepository(this IServiceCollection services) 
        => services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    
}