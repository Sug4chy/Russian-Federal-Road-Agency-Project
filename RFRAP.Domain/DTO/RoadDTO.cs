namespace RFRAP.Domain.DTO;

public class RoadDTO
{
    public Guid Id { get; set; }
    
    public CityDTO? SourceCity { get; set; }
    public CityDTO? DestCity { get; set; }

    public PointDTO ImageMid { get; set; }
    public double ImageScale { get; set; }

    public ICollection<MarkerPointDTO> Points { get; set; } =
        Array.Empty<MarkerPointDTO>();
}