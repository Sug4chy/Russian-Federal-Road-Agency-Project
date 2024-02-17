using NpgsqlTypes;
using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class GasStation : AuditableEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    
    public Guid SegmentId { get; set; }
    public Segment? Segment { get; set; }
}