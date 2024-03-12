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
    }
}