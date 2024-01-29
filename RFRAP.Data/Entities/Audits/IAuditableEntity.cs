namespace RFRAP.Data.Entities.Audits;

public interface IAuditableEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime LastlyEditedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}