using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class RoadEntityConfiguration : IEntityTypeConfiguration<Road>
{
    public void Configure(EntityTypeBuilder<Road> builder)
    {
        builder.ToTable("road");

        builder.HasKey(r => r.Id);
        builder.HasAlternateKey(r => r.Name);

        builder
            .HasMany(r => r.Segments)
            .WithOne(s => s.Road)
            .HasForeignKey(s => s.RoadId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(r => r.DeletedAt == null);
    }
}