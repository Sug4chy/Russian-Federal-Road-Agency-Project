using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class AdvertisementEntityConfiguration : IEntityTypeConfiguration<Advertisement>
{
    public void Configure(EntityTypeBuilder<Advertisement> builder)
    {
        builder.ToTable("advertisement");

        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Road)
            .WithMany(r => r.Advertisements)
            .HasForeignKey(a => a.RoadId);

        builder.HasQueryFilter(a => a.ExpirationDateTime > DateTime.UtcNow 
                                    && a.DeletedAt != null);

        builder.HasData(new Advertisement
        {
            Id = Guid.NewGuid(),
            Title = "Объявления для М-5",
            MessageText = "На дороге всё спокойно, просто тестируем объявления",
            ExpirationDateTime = DateTime.Today.AddDays(10),
            RoadId = new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89")
        });
    }
}