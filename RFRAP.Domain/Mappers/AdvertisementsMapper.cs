using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Mappers;

public class AdvertisementsMapper : IMapper<Advertisement, AdvertisementDto>
{
    public AdvertisementDto Map(Advertisement from)
        => new()
        {
            Message = from.MessageText,
            Title = from.Title
        };
}