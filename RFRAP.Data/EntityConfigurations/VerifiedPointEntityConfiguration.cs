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

        builder.HasData(new VerifiedPoint
        {
            Id = Guid.NewGuid(),
            Longitude = 61.133454,
            Latitude = 54.996371,
            Name = "Кафе Урал",
            SegmentId = new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"),
            Type = VerifiedPointType.Cafes
        }, new VerifiedPoint
        {
            Id = Guid.NewGuid(),
            Longitude = 61.043416, 
            Latitude = 54.989184,
            Name = "Subway",
            SegmentId = new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"),
            Type = VerifiedPointType.Cafes
        }, new VerifiedPoint
        {
            Id = Guid.NewGuid(),
            Latitude = 54.987987, 
            Longitude = 61.044195,
            Name = "РегионUNO",
            SegmentId = new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"),
            Type = VerifiedPointType.GasStations
        }, new VerifiedPoint
        {
            Id = Guid.NewGuid(),
            Latitude = 54.945493, 
            Longitude = 60.827627,
            Name = "Salavat",
            SegmentId = new Guid("4b4a2da6-f246-42be-a991-4ff710a543ef"),
            Type = VerifiedPointType.GasStations
        }, new VerifiedPoint
        {
            Id = Guid.NewGuid(),
            Latitude = 55.233765, 
            Longitude = 62.032693,
            Name = "Челябнефтепродукт",
            SegmentId = new Guid("c9db979a-5842-4783-9f49-6bfe049879ff"),
            Type = VerifiedPointType.GasStations
        });
    }
}