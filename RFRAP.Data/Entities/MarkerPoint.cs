using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class MarkerPoint : AuditableEntity
{
    public Guid Id { get; set; }
    public Point Coordinates { get; set; }
    
    public Guid RoadId { get; set; }
    public Road? Road { get; set; }
    
    public MarkerType Type { get; set; }
}