using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.DbTypesConverters;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class MarkerPointConfiguration : IEntityTypeConfiguration<MarkerPoint>
{
    public void Configure(EntityTypeBuilder<MarkerPoint> builder)
    {
        builder.ToTable("Marker point");

        builder.HasKey(mp => mp.Id);

        builder.HasOne(mp => mp.Road)
            .WithMany(r => r.Points)
            .HasForeignKey(mp => mp.RoadId);

        builder.Property(mp => mp.Coordinates)
            .HasConversion(new PostgreSqlPointsConverter());
        
        builder.Property(mp => mp.Type)
            .HasConversion<string>();
    }
}