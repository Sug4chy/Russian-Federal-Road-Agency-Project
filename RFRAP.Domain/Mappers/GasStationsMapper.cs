using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Mappers;

public class GasStationsMapper : IMapper<GasStation, GasStationDto>
{
    public GasStationDto Map(GasStation from)
        => new()
        {
            Name = from.Name,
            X = from.Coordinates.X,
            Y = from.Coordinates.Y
        };
}