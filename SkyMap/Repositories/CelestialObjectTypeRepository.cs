using Microsoft.EntityFrameworkCore;
using SkyMap.Data;
using SkyMap.Entities;
using SkyMap.Interfaces;

namespace SkyMap.Repositories;

public class CelestialObjectTypeRepository : ICelestialObjectTypeRepository
{
    private readonly DataContext _dataContext;

    public CelestialObjectTypeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<CelestialObjectType> AddCelestialObjectType(string name)
    {
        CelestialObjectType type = new();
        type.Id = Guid.NewGuid();
        type.Name = name;

        await _dataContext.CelestialObjectTypes.AddAsync(type);
        await _dataContext.SaveChangesAsync();
        return type;
    }

    public async Task<bool> RemoveCelestialObjectType(Guid id)
    {
        var type = await _dataContext.CelestialObjectTypes.FindAsync(id);
        if (type == null)
        {
            return false;
        }

        _dataContext.CelestialObjectTypes.Remove(type);
        await _dataContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<CelestialObjectType>> GetCelestialObjectTypes()
    {
        var types = await _dataContext.CelestialObjectTypes.ToListAsync();
        return types;
    }

    public async Task<CelestialObjectType?> GetCelestialObjectType(Guid id)
    {
        var type = await _dataContext.CelestialObjectTypes.FindAsync(id);
        return type;
    }
}