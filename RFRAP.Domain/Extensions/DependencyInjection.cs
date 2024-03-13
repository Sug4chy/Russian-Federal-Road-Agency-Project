using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Handlers.Files;
using RFRAP.Domain.Handlers.Mobile;
using RFRAP.Domain.Handlers.Roads;
using RFRAP.Domain.Handlers.Utility;
using RFRAP.Domain.Mappers;
using RFRAP.Domain.Requests.Files;
using RFRAP.Domain.Requests.Mobile;
using RFRAP.Domain.Requests.Roads;
using RFRAP.Domain.Requests.Utility;
using RFRAP.Domain.Services.Distance;
using RFRAP.Domain.Services.Files;
using RFRAP.Domain.Services.Roads;
using RFRAP.Domain.Services.Segments;
using RFRAP.Domain.Services.UnverifiedPoints;
using RFRAP.Domain.Services.VerifiedPoints;
using RFRAP.Domain.Validators.Files;
using RFRAP.Domain.Validators.Mobile;
using RFRAP.Domain.Validators.Roads;
using RFRAP.Domain.Validators.Utility;

namespace RFRAP.Domain.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
        => services
            .AddScoped<ISegmentService, SegmentService>()
            .AddScoped<IUnverifiedPointsService, UnverifiedPointsService>()
            .AddScoped<IVerifiedPointsService, VerifiedPointsService>()
            .AddScoped<IFileService, FileService>()
            .AddScoped<IRoadService, RoadService>()
            .AddScoped<IDistanceCalculator, DistanceCalculator>();

    public static IServiceCollection AddHandlers(this IServiceCollection services)
        => services
            .AddScoped<AddUnverifiedPointHandler>()
            .AddScoped<GetVerifiedPointsHandler>()
            .AddScoped<AddVerifiedPointHandler>()
            .AddScoped<AddSegmentHandler>()
            .AddScoped<SaveFileForPointHandler>()
            .AddScoped<AddRoadHandler>()
            .AddScoped<GetAdvertisementsByRoadNameHandler>()
            .AddScoped<GetVerifiedPointsInRadiusHandler>();

    public static IServiceCollection AddValidators(this IServiceCollection services)
        => services
            .AddScoped<IValidator<AddUnverifiedPointRequest>, AddUnverifiedPointRequestValidator>()
            .AddScoped<IValidator<GetVerifiedPointsRequest>, GetVerifiedPointsRequestValidator>()
            .AddScoped<IValidator<AddVerifiedPointRequest>, AddVerifiedPointValidator>()
            .AddScoped<IValidator<AddSegmentRequest>, AddSegmentRequestValidator>()
            .AddScoped<IValidator<SaveFileForPointRequest>, SaveFileForPointRequestValidator>()
            .AddScoped<IValidator<AddRoadRequest>, AddRoadRequestValidator>()
            .AddScoped<IValidator<GetAdvertisementsByRoadNameRequest>, 
                GetAdvertisementsByRoadNameRequestValidator>()
            .AddScoped<IValidator<GetVerifiedPointsInRadiusRequest>, 
                GetVerifiedPointsInRadiusRequestValidator>();

    public static IServiceCollection AddMappers(this IServiceCollection services)
        => services
            .AddScoped<IMapper<VerifiedPoint, VerifiedPointDto>, VerifiedPointsMapper>()
            .AddScoped<IMapper<Advertisement, AdvertisementDto>, AdvertisementsMapper>()
            .AddScoped<IMapper<VerifiedPoint, MobileVerifiedPointDto>, MobileVerifiedPointMapper>();
}