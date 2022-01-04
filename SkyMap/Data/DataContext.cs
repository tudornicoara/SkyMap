using Microsoft.EntityFrameworkCore;
using SkyMap.Entities;

namespace SkyMap.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    // = null! is just for the IDE to shut up about non-nullable properties
    public DbSet<DiscoverySourceType> DiscoverySourceTypes { get; set; } = null!;
    public DbSet<DiscoverySource> DiscoverySources { get; set; } = null!;
    public DbSet<CelestialObjectType> CelestialObjectTypes { get; set; } = null!;
    public DbSet<CelestialObject> CelestialObjects { get; set; } = null!;
}