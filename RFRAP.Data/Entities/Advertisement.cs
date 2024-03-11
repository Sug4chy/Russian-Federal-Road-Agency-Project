using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class Advertisement : AuditableEntity
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string MessageText { get; set; }
    public required DateTime ExpirationDateTime { get; set; }
    
    public Guid RoadId { get; set; }
    public Road? Road { get; set; }
}