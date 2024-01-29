using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class GasStationEntityConfiguration : IEntityTypeConfiguration<GasStation>
{
    public void Configure(EntityTypeBuilder<GasStation> builder)
    {
        builder.ToTable("gas_station");

        builder.HasKey(gs => gs.Id);

        builder
            .HasOne(gs => gs.Segment)
            .WithMany(s => s.GasStations)
            .HasForeignKey(gs => gs.SegmentId);
    }
}