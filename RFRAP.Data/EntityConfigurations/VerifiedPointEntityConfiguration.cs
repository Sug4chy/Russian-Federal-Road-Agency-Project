using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class VerifiedPointEntityConfiguration : IEntityTypeConfiguration<VerifiedPoint>
{
    public void Configure(EntityTypeBuilder<VerifiedPoint> builder)
    {
        builder.ToTable("verified_point");

        builder.HasKey(vp => vp.Id);

        builder
            .HasOne(vp => vp.Segment)
            .WithMany(s => s.VerifiedPoints)
            .HasForeignKey(vp => vp.SegmentId);

        builder.Property(vp => vp.Type).HasConversion<string>();
        builder.HasQueryFilter(vp => vp.DeletedAt != null);
    }
}