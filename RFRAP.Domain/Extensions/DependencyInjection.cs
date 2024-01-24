using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Handlers;
using RFRAP.Domain.Handlers.Files;
using RFRAP.Domain.Handlers.Roads;
using RFRAP.Domain.Mappers;
using RFRAP.Domain.Requests;
using RFRAP.Domain.Requests.Roads;
using RFRAP.Domain.Services.GasStations;
using RFRAP.Domain.Services.Segments;
using RFRAP.Domain.Services.UnverifiedPoints;
using RFRAP.Domain.Validators;

namespace RFRAP.Domain.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
        => services
            .AddScoped<ISegmentService, SegmentService>()
            .AddScoped<IUnverifiedPointsService, UnverifiedPointsService>()
            .AddScoped<IGasStationService, GasStationService>();

    public static IServiceCollection AddHandlers(this IServiceCollection services)
        => services
            .AddScoped<AddUnverifiedPointHandler>()
            .AddScoped<GetGasStationsHandler>()
            .AddScoped<AddGasStationHandler>()
            .AddScoped<SaveFileForPointHandler>();

    public static IServiceCollection AddValidators(this IServiceCollection services)
        => services
            .AddScoped<IValidator<AddUnverifiedPointRequest>, AddUnverifiedPointRequestValidator>()
            .AddScoped<IValidator<GetGasStationsRequest>, GetGasStationsRequestValidator>()
            .AddScoped<IValidator<AddGasStationRequest>, AddGasStationValidator>();

    public static IServiceCollection AddMappers(this IServiceCollection services)
        => services
            .AddScoped<IMapper<GasStation, GasStationDto>, GasStationsMapper>();
}