using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class SegmentEntityConfiguration : IEntityTypeConfiguration<Segment>
{
    public void Configure(EntityTypeBuilder<Segment> builder)
    {
        builder.ToTable("segment");

        builder.HasKey(s => s.Id);
        
        builder
            .HasOne(s => s.Road)
            .WithMany(r => r.Segments)
            .HasForeignKey(s => s.RoadId);

        builder
            .HasMany(s => s.VerifiedPoints)
            .WithOne(vp => vp.Segment);
        
        builder
            .HasMany(s => s.UnverifiedPoints)
            .WithOne(up => up.Segment);

        builder.HasQueryFilter(s => s.DeletedAt != null);
    }
}