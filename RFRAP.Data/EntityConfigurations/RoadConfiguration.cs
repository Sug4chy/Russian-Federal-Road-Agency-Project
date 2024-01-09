using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.DbTypesConverters;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class RoadConfiguration : IEntityTypeConfiguration<Road>
{
    public void Configure(EntityTypeBuilder<Road> builder)
    {
        builder.ToTable("Road");

        builder.HasKey(r => r.Id);

        builder.HasMany(r => r.Points)
            .WithOne(mp => mp.Road)
            .HasForeignKey(mp => mp.RoadId);

        builder.HasOne(r => r.SourceCity)
            .WithMany(c => c.RoadsFrom)
            .HasForeignKey(r => r.SourceCityId);

        builder.HasOne(r => r.DestCity)
            .WithMany(c => c.RoadsTo)
            .HasForeignKey(r => r.DestCityId);
        
        /*builder.Property(r => r.ImageScale)
            .HasConversion(new PostgreSqlPointsConverter());*/
        builder.Property(r => r.ImageMid)
            .HasConversion(new PostgreSqlPointsConverter());

        builder.Property(r => r.ImageScale).IsRequired();
    }
}