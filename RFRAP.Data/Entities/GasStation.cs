using NpgsqlTypes;
using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class GasStation : AuditableEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public NpgsqlPoint Coordinates { get; set; }
    
    public Guid SegmentId { get; set; }
    public Segment? Segment { get; set; }
}