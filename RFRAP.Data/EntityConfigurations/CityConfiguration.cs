using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("City");

        builder.HasKey(c => c.Id);
        builder.HasAlternateKey(c => c.Name);

        builder.HasMany(c => c.RoadsFrom)
            .WithOne(r => r.SourceCity)
            .HasForeignKey(r => r.SourceCityId);

        builder.HasMany(c => c.RoadsTo)
            .WithOne(r => r.DestCity)
            .HasForeignKey(r => r.DestCityId);
    }
}