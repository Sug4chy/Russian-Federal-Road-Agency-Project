using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFRAP.Data.Entities;

namespace RFRAP.Data.EntityConfigurations;

public class RoadEntityConfiguration : IEntityTypeConfiguration<Road>
{
    public void Configure(EntityTypeBuilder<Road> builder)
    {
        builder.ToTable("road");

        builder.HasKey(r => r.Id);
        builder.HasAlternateKey(r => r.Name);

        builder
            .HasMany(r => r.Segments)
            .WithOne(s => s.Road)
            .HasForeignKey(s => s.RoadId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(r => r.DeletedAt == null);

        builder.HasData(new Road
        {
            Id = new Guid("0d396ef7-78e3-4980-9d78-a61df9ee1f89"),
            Name = "М-5"
        }, new Road
        {
            Id = new Guid("a1a5a180-1e8f-457b-b574-c6e227cb02fb"),
            Name = "А-310"
        }, new Road
        {
            Id = new Guid("37d115a0-10e8-444f-9379-78a231852962"),
            Name = "Р-254"
        }, new Road
        {
            Id = new Guid("9d7a20b1-3b91-4d02-a3e5-c71ebab7d0e7"),
            Name = "Р-354"
        });
    }
}