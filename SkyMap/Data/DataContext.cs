using Microsoft.EntityFrameworkCore;
using SkyMap.Entities;

namespace SkyMap.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<DiscoverySourceType> DiscoverySourceTypes { get; set; }
    public DbSet<DiscoverySource> DiscoverySources { get; set; }
    public DbSet<CelestialObjectType> CelestialObjectTypes { get; set; }
    public DbSet<CelestialObject> CelestialObjects { get; set; }
}