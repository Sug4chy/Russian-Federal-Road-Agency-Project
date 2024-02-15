﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RFRAP.Data.Entities;

namespace RFRAP.Data.Context;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityUserContext<User>(options)
{
    public DbSet<Road> Roads => Set<Road>();
    public DbSet<Segment> Segments => Set<Segment>();
    public DbSet<GasStation> GasStations => Set<GasStation>();
    public DbSet<UnverifiedPoint> UnverifiedPoints => Set<UnverifiedPoint>();
    public DbSet<AttachmentFile> Files => Set<AttachmentFile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}