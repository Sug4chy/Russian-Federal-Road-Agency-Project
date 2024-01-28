﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class AttachmentFileEntityConfiguration : IEntityTypeConfiguration<AttachmentFile>
{
    public void Configure(EntityTypeBuilder<AttachmentFile> builder)
    {
        builder.ToTable("AttachmentFile");

        builder.HasKey(af => af.Id);
        builder.HasAlternateKey(af => af.UniqueName);

        builder.HasOne(af => af.Point)
            .WithOne(uv => uv.File)
            .HasForeignKey<AttachmentFile>(af => af.PointId);
    }
}