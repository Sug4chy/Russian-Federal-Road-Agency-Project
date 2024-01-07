using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NpgsqlTypes;
using RFRAP.Data.Entities;

namespace RFRAP.Data.DbTypesConverters;

public class PostgreSqlPointsConverter()
    : ValueConverter<Point, NpgsqlPoint>(
        p => new NpgsqlPoint(p.X, p.Y),
        np => new Point(np.X, np.Y));