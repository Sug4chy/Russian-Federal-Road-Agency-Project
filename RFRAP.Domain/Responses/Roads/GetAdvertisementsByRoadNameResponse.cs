using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Responses.Roads;

public record GetAdvertisementsByRoadNameResponse
{
    public required AdvertisementDto[] Advertisements { get; init; }
}