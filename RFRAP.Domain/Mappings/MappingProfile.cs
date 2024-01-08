using AutoMapper;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTO;

namespace RFRAP.Domain.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Point, PointDTO>().ReverseMap();
        CreateMap<City, CityDTO>().ReverseMap();
        CreateMap<MarkerPoint, MarkerPointDTO>().ReverseMap();
        CreateMap<MarkerType, MarkerTypeDTO>().ReverseMap();
        CreateMap<Road, RoadDTO>().ReverseMap();
    }
}