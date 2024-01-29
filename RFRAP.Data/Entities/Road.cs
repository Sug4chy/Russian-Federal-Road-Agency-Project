using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class Road : AuditableEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Segment>? Segments { get; set; }
}