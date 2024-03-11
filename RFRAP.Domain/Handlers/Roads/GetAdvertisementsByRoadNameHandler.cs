using FluentValidation;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Mappers;
using RFRAP.Domain.Requests.Roads;
using RFRAP.Domain.Responses.Roads;
using RFRAP.Domain.Services.Roads;

namespace RFRAP.Domain.Handlers.Roads;

public class GetAdvertisementsByRoadNameHandler(
    IValidator<GetAdvertisementsByRoadNameRequest> validator,
    IRoadService roadService,
    IMapper<Advertisement, AdvertisementDto> mapper)
{
    public async Task<GetAdvertisementsByRoadNameResponse> HandleAsync(GetAdvertisementsByRoadNameRequest request, 
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var road = await roadService.GetRoadWithAdvertisementsByNameAsync(request.RoadName, ct);
        NotFoundException.ThrowIfNull(road, RoadErrors.NoSuchRoadWithName(request.RoadName));

        return new GetAdvertisementsByRoadNameResponse
        {
            Advertisements = road!.Advertisements is null 
                ? Array.Empty<AdvertisementDto>()
                : road.Advertisements.Select(mapper.Map).ToArray()
        };
    }
}