using NpgsqlTypes;

namespace RFRAP.Data.Entities;

public class Point
{
    public Guid Id { get; set; }
    public NpgsqlPoint Coordinates { get; set; }
    public Guid RoadId { get; set; }
    public string PointType { get; set; }
}