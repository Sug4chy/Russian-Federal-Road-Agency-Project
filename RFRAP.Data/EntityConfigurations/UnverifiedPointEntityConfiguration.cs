using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class UnverifiedPointEntityConfiguration : IEntityTypeConfiguration<UnverifiedPoint>
{
    public void Configure(EntityTypeBuilder<UnverifiedPoint> builder)
    {
        builder.ToTable("unverified_point");

        builder.HasKey(up => up.Id);

        builder
            .HasOne(up => up.Segment)
            .WithMany(s => s.UnverifiedPoints)
            .HasForeignKey(up => up.SegmentId);

        builder
            .HasOne(up => up.File)
            .WithOne(af => af.Point)
            .HasForeignKey<AttachmentFile>(af => af.PointId);

        builder.Property(up => up.Type).HasConversion<string>();
        builder.HasQueryFilter(up => up.DeletedAt == null);
    }
}