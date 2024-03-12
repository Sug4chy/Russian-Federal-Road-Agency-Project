using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Mappers;

public class MobileVerifiedPointMapper : IMapper<VerifiedPoint, MobileVerifiedPointDto>
{
    public MobileVerifiedPointDto Map(VerifiedPoint from)
        => new()
        {
            Name = from.Name,
            Coordinates = new PointDto
            {
                Longitude = from.Longitude,
                Latitude = from.Latitude
            },
            Type = from.Type
        };
}