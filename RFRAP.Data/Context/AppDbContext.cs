using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Entities;

namespace RFRAP.Data.Context;

public sealed class AppDbContext : DbContext
{
    public DbSet<Road> Roads => Set<Road>();
    public DbSet<GasStation> GasStations => Set<GasStation>();
    public DbSet<UnverifiedPoint> UnverifiedPoints => Set<UnverifiedPoint>();
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}