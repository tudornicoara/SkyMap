using System.Text.Json;
using SkyMap.Entities;

namespace SkyMap.Data;

public static class Seed
{
    public static async Task SeedData(DataContext context)
    {
        if (!context.DiscoverySourceTypes.Any() && !context.CelestialObjectTypes.Any())
        {
            var discoverySourceTypes = new List<DiscoverySourceType>
            {
                new()
                {
                    Id = new Guid("a22fbd20-30ec-4a0d-beaf-f2870f53c760"),
                    Name = "Space telescope"
                },
                new()
                {
                    Id = new Guid("cd4b1f86-62cb-4f84-81fd-5de0dee4d524"),
                    Name = "Ground telescope"
                },
                new()
                {
                    Id = new Guid("31088616-7fb5-4793-9765-9c8ccd223260"),
                    Name = "Other"
                }
            };

            var celestialObjectTypes = new List<CelestialObjectType>
            {
                new()
                {
                    Id = new Guid("2adc4216-1a08-4b0c-b857-3238206bc4d0"),
                    Name = "Planet"
                },
                new()
                {
                    Id = new Guid("33358925-63d5-43ed-b222-fa5738689858"),
                    Name = "Star"
                },
                new()
                {
                    Id = new Guid("afb9714f-90f3-44ce-bf5d-03d422bc1f75"),
                    Name = "Black hole"
                }
            };

            await context.DiscoverySourceTypes.AddRangeAsync(discoverySourceTypes);
            await context.CelestialObjectTypes.AddRangeAsync(celestialObjectTypes);
            
            string discoverySourcesJson = await File.ReadAllTextAsync("Data/DiscoverySources.json");
            var discoverySources = JsonSerializer.Deserialize<List<DiscoverySource>>(discoverySourcesJson);
            if (discoverySources != null && discoverySources.Any())
            {
                await context.DiscoverySources.AddRangeAsync(discoverySources);   
            }

            string celestialObjectsJson = await File.ReadAllTextAsync("Data/CelestialObjects.json");
            var celestialObjects = JsonSerializer.Deserialize<List<CelestialObject>>(celestialObjectsJson);
            if (celestialObjects != null && celestialObjects.Any())
            {
                await context.CelestialObjects.AddRangeAsync(celestialObjects);
            }
            
            await context.SaveChangesAsync();
        }
    }
}