using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class AttachmentFileEntityConfiguration : IEntityTypeConfiguration<AttachmentFile>
{
    public void Configure(EntityTypeBuilder<AttachmentFile> builder)
    {
        builder.ToTable("attachment_file");

        builder.HasKey(af => af.Id);
        builder.HasAlternateKey(af => af.UniqueName);

        builder.HasOne(af => af.Point)
            .WithOne(up => up.File)
            .HasForeignKey<AttachmentFile>(af => af.PointId);

        builder.HasQueryFilter(af => af.DeletedAt != null);
    }
}