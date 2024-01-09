using Microsoft.Extensions.DependencyInjection;
using RFRAP.Domain.Handlers;
using RFRAP.Domain.Interfaces;
using RFRAP.Domain.Services;

namespace RFRAP.Domain.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<MainHandler>();
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IRoadService, RoadService>();
        //services.AddScoped<IMarkerPointService, MarkerPointService>();
        //services.AddScoped<IMarkerTypeService, MarkerTypeService>();
        return services;
    }
}