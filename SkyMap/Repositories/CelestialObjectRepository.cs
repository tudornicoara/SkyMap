using Microsoft.EntityFrameworkCore;
using SkyMap.Data;
using SkyMap.DTOs;
using SkyMap.Entities;
using SkyMap.Interfaces;

namespace SkyMap.Repositories;

public class CelestialObjectRepository : ICelestialObjectRepository
{
    private readonly DataContext _dataContext;
    private readonly ICelestialObjectTypeRepository _celestialObjectTypeRepository;

    public CelestialObjectRepository(DataContext dataContext, ICelestialObjectTypeRepository celestialObjectTypeRepository)
    {
        _dataContext = dataContext;
        _celestialObjectTypeRepository = celestialObjectTypeRepository;
    }
    
    public async Task<CelestialObject> AddCelestialObject(CelestialObjectDto celestialObjectDto)
    {
        if (celestialObjectDto.CelestialObjectTypeId == null)
        {
            try
            {
                double massNumber = Double.Parse(celestialObjectDto.Mass!);
                var type = "Unknown";
            
                // PLANET
                if (massNumber <= Double.Parse("1.898e27"))
                {
                    type = "Planet";
                }
                else
                {
                    // STAR
                    if (int.Parse(celestialObjectDto.SurfaceTemperature!) > 2500)
                    {
                        type = "Star";
                    }
                }

                // BLACK HOLE
                const double grav = 6.6720e-08;
                const double lightSpeed = 2.9979e10;
                double schwarzChildRadius = 2 * grav * massNumber / Math.Pow(lightSpeed, 2);
            
                if (Double.Parse(celestialObjectDto.EquatorialDiameter!) / 2 < schwarzChildRadius)
                {
                    type = "Black hole";
                }
            
                var celestialObjectType = await _celestialObjectTypeRepository.GetCelestialObjectTypeByName(type);
            
                celestialObjectDto.CelestialObjectTypeId = celestialObjectType!.Id.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        var celestialObject = new CelestialObject
        {
            Id = Guid.NewGuid(),
            Name = celestialObjectDto.Name,
            Mass = celestialObjectDto.Mass,
            EquatorialDiameter = celestialObjectDto.EquatorialDiameter,
            SurfaceTemperature = celestialObjectDto.SurfaceTemperature,
            DiscoveryDate = celestialObjectDto.DiscoveryDate,
            DiscoverySourceId = Guid.Parse(celestialObjectDto.DiscoverySourceId!),
            CelestialObjectTypeId = Guid.Parse(celestialObjectDto.CelestialObjectTypeId!)
        };

        await _dataContext.CelestialObjects.AddAsync(celestialObject);
        await _dataContext.SaveChangesAsync();
        return celestialObject;
    }

    public async Task<bool> RemoveCelestialObject(Guid id)
    {
        var celestialObject = await _dataContext.CelestialObjects.FindAsync(id);
        if (celestialObject == null)
        {
            return false;
        }

        _dataContext.CelestialObjects.Remove(celestialObject);
        await _dataContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<CelestialObject>> GetCelestialObjects()
    {
        var celestialObjects = await _dataContext.CelestialObjects
            .Include(x => x.DiscoverySource)
            .Include(x => x.Type)
            .ToListAsync();
        return celestialObjects;
    }

    public async Task<CelestialObject?> GetCelestialObject(Guid id)
    {
        var celestialObject = await _dataContext.CelestialObjects
            .Include(x => x.DiscoverySource)
            .Include(x => x.Type)
            .FirstOrDefaultAsync(x => x.Id == id);
        return celestialObject;
    }

    public async Task<CelestialObject?> GetCelestialObjectByName(string name)
    {
        var celestialObject = await _dataContext.CelestialObjects
            .Include(x => x.DiscoverySource)
            .Include(x => x.Type)
            .FirstOrDefaultAsync(c => c.Name == name);

        return celestialObject;
    }
}