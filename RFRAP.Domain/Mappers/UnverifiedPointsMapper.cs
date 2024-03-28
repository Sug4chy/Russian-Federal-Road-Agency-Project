using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Mappers;

public class UnverifiedPointsMapper : IMapper<UnverifiedPoint, UnverifiedPointDto>
{
    public UnverifiedPointDto Map(UnverifiedPoint from)
        => new()
        {
            Type = from.Type.ToString(),
            Coordinates = new PointDto
            {
                Latitude = from.Latitude,
                Longitude = from.Longitude
            },
            Description = from.Description
        };
}