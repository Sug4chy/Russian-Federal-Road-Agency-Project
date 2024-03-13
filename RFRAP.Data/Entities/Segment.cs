using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class Segment : AuditableEntity
{
    public Guid Id { get; set; }
    public double Longitude1 { get; set; }
    public double Latitude1 { get; set; }
    public double Longitude2 { get; set; }
    public double Latitude2 { get; set; }
    
    public Guid RoadId { get; set; }
    public Road? Road { get; set; }

    public ICollection<VerifiedPoint> VerifiedPoints { get; set; } = new List<VerifiedPoint>();
    public ICollection<UnverifiedPoint>? UnverifiedPoints { get; set; }
}