namespace RFRAP.Data.Entities.Audits;

public class AuditableEntity : IAuditableEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime LastlyEditedAt { get; set; }
    public DateTime? DeletedAt { get; set; } = null;
}