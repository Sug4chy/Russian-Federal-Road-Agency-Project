using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Mappers;

public class VerifiedPointsMapper : IMapper<VerifiedPoint, VerifiedPointDto>
{
    public VerifiedPointDto Map(VerifiedPoint from)
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