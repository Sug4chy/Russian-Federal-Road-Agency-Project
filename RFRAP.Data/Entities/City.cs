using RFRAP.Data.Entities.Audits;

namespace RFRAP.Data.Entities;

public class City : AuditableEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Road>? RoadsFrom { get; set; }
    public ICollection<Road>? RoadsTo { get; set; }
}