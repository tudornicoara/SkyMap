using Microsoft.EntityFrameworkCore;
using SkyMap.Data;
using SkyMap.Interfaces;
using SkyMap.Repositories;

namespace SkyMap.Extensions;

public static class ApplicationServiceExtensions
{
    public static void AddAplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IDiscoverySourceTypeRepository, DiscoverySourceTypeRepository>();
        builder.Services.AddTransient<ICelestialObjectTypeRepository, CelestialObjectTypeRepository>();
        builder.Services.AddTransient<IDiscoverySourceRepository, DiscoverySourceRepository>();
        builder.Services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty);
        });
    }
    
    public static async Task MigrateAndSeedDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();

        try
        {
            var context = services.GetRequiredService<DataContext>();
            await context.Database.MigrateAsync();
            await Seed.SeedData(context);
        }
        catch (Exception e)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(e, "An error occured during migration");
        }
    }
}

