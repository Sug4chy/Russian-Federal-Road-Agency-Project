using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class UnverifiedPoint : AuditableEntity
{
    public Guid Id { get; set; }
    public bool IsVerified { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string? Description { get; set; }
    public required UnverifiedPointType Type { get; set; }
    
    public Guid SegmentId { get; set; }
    public Segment? Segment { get; set; }
    
    public AttachmentFile? File { get; set; }
}