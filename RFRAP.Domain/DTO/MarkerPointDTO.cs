namespace RFRAP.Domain.DTO;

public class MarkerPointDTO
{
    public Guid Id { get; set; }
    public PointDTO Coordinates { get; set; }
    public Guid RoadId { get; set; }
    public RoadDTO? Road { get; set; }
    public MarkerTypeDTO Type { get; set; }
}