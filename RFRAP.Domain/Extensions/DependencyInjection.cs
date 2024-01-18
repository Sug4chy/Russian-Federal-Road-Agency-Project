using Microsoft.Extensions.DependencyInjection;
using RFRAP.Domain.Handlers;
using RFRAP.Domain.Services.Segments;
using RFRAP.Domain.Services.UnverifiedPoints;

namespace RFRAP.Domain.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
        => services.AddScoped<ISegmentService, SegmentService>()
            .AddScoped<IUnverifiedService, UnverifiedService>();

    public static IServiceCollection AddHandlers(this IServiceCollection service)
        => service.AddScoped<AddUnverifiedPointHandler>();
}