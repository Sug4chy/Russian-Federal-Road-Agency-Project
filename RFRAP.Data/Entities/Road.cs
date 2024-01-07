using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class Road : AuditableEntity
{
    public Guid Id { get; set; }
    
    public Guid SourceCityId { get; set; }
    public City? SourceCity { get; set; }
    
    public Guid DestCityId { get; set; }
    public City? DestCity { get; set; }
    
    public Point ImageMid { get; set; }
    public double ImageScale { get; set; }
    
    public ICollection<MarkerPoint>? Points { get; set; }
}