using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RFRAP.Domain.Handlers;
using RFRAP.Domain.Requests;
using RFRAP.Domain.Services.Segments;
using RFRAP.Domain.Services.UnverifiedPoints;
using RFRAP.Domain.Validators;

namespace RFRAP.Domain.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
        => services.AddScoped<ISegmentService, SegmentService>()
            .AddScoped<IUnverifiedPointsService, UnverifiedPointsService>();

    public static IServiceCollection AddHandlers(this IServiceCollection services)
        => services.AddScoped<AddUnverifiedPointHandler>();

    public static IServiceCollection AddValidators(this IServiceCollection services)
        => services.AddScoped<IValidator<AddUnverifiedPointRequest>, AddUnverifiedPointRequestValidator>();
    
}