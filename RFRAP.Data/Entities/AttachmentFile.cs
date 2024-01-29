using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class AttachmentFile : AuditableEntity
{
    public Guid Id { get; set; }
    public required string UniqueName { get; set; }
    public required string ContentType { get; set; }
    
    public Guid PointId { get; set; }
    public UnverifiedPoint? Point { get; set; }
}