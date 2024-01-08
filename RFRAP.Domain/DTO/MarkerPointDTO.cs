namespace RFRAP.Domain.DTO;

public class MarkerPointDTO
{
    public Guid Id { get; set; }
    public PointDTO Coordinates { get; set; }
    public MarkerTypeDTO Type { get; set; }
}