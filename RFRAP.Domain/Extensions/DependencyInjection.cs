﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Handlers.Files;
using RFRAP.Domain.Handlers.Roads;
using RFRAP.Domain.Mappers;
using RFRAP.Domain.Requests.Files;
using RFRAP.Domain.Requests.Roads;
using RFRAP.Domain.Services.Files;
using RFRAP.Domain.Services.GasStations;
using RFRAP.Domain.Services.Segments;
using RFRAP.Domain.Services.UnverifiedPoints;
using RFRAP.Domain.Validators.Files;
using RFRAP.Domain.Validators.Roads;

namespace RFRAP.Domain.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
        => services
            .AddScoped<ISegmentService, SegmentService>()
            .AddScoped<IUnverifiedPointsService, UnverifiedPointsService>()
            .AddScoped<IGasStationService, GasStationService>()
            .AddScoped<IFileService, FileService>();

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
            .AddScoped<IValidator<AddGasStationRequest>, AddGasStationValidator>()
            .AddScoped<IValidator<SaveFileForPointRequest>, SaveFileForPointRequestValidator>();

    public static IServiceCollection AddMappers(this IServiceCollection services)
        => services
            .AddScoped<IMapper<GasStation, GasStationDto>, GasStationsMapper>();
}