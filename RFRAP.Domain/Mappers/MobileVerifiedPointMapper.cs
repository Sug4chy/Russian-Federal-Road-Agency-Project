using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Mappers;

public class MobileVerifiedPointMapper : IMapper<VerifiedPoint, MobileVerifiedPointDto>
{
    public MobileVerifiedPointDto Map(VerifiedPoint from)
        => new()
        {
            Latitude = from.Latitude,
            Longitude = from.Longitude,
            Name = from.Name,
            Type = from.Type
        };
}