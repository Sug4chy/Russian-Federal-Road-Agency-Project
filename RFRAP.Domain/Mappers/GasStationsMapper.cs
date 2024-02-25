using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Mappers;

public class GasStationsMapper : IMapper<VerifiedPoint, VerifiedPointDto>
{
    public VerifiedPointDto Map(VerifiedPoint from)
        => new()
        {
            Name = from.Name,
            Longitude = from.Longitude,
            Latitude = from.Latitude,
            Type = from.Type
        };
}