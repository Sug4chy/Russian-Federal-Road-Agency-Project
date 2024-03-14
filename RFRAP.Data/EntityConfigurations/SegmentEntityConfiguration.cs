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

        builder.HasData(new Segment
        {
            Id = new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"),
            RoadId = new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89"),
            Latitude1 = 0,
            Longitude1 = 0,
            Longitude2 = 0,
            Latitude2 = 0
        }, new Segment
        {
            Id = Guid.NewGuid(),
            RoadId = new Guid("a1a5a180-1e8f-457b-b574-c6e227cb02fb"),
            Latitude1 = 0,
            Longitude1 = 0,
            Longitude2 = 0,
            Latitude2 = 0
        }, new Segment
        {
            Id = new Guid("c9db979a-5842-4783-9f49-6bfe049879ff"),
            RoadId = new Guid("37d115a0-10e8-444f-9379-78a231852962"),
            Latitude1 = 0,
            Longitude1 = 0,
            Longitude2 = 0,
            Latitude2 = 0
        }, new Segment
        {
            Id = Guid.NewGuid(),
            RoadId = new Guid("9d7a20b1-3b91-4d02-a3e5-c71ebab7d0e7"),
            Latitude1 = 0,
            Longitude1 = 0,
            Longitude2 = 0,
            Latitude2 = 0
        });
    }
}