namespace RFRAP.Domain.DTO;

public class CityDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<RoadDTO> RoadsFrom { get; set; }
    public ICollection<RoadDTO> RoadsTo { get; set; }
}