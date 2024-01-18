using NpgsqlTypes;
using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class UnverifiedPoint : AuditableEntity
{
    public Guid Id { get; set; }
    public bool IsVerified { get; set; }
    public NpgsqlPoint Coordinates { get; set; }
    public string? FileReference { get; set; }

    public Guid SegmentId { get; set; }
    public Segment? Segment { get; set; }
}