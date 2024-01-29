using NpgsqlTypes;
using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class Segment : AuditableEntity
{
    public Guid Id { get; set; }
    public NpgsqlPoint Point1 { get; set; }
    public NpgsqlPoint Point2 { get; set; }
    
    public Guid RoadId { get; set; }
    public Road? Road { get; set; }

    public ICollection<GasStation>? GasStations { get; set; }
    public ICollection<UnverifiedPoint>? UnverifiedPoints { get; set; }
}