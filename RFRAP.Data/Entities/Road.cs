using NpgsqlTypes;

namespace RFRAP.Data.Entities;

public class Road
{
    public Guid Id { get; set; }
    public Guid City1Id { get; set; }
    public Guid City2Id { get; set; }
    public NpgsqlPoint ImageMid { get; set; }
    public float Scale { get; set; }
}