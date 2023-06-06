using SkyMap.DTOs;
using SkyMap.Entities;
using SkyMap.Interfaces;

namespace SkyMap.Repositories;

public class CelestialObjectRepository : ICelestialObjectRepository
{
    public Task<CelestialObject> AddCelestialObject(CelestialObjectDto celestialObjectDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveCelestialObject(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CelestialObject>> GetCelestialObjects()
    {
        throw new NotImplementedException();
    }

    public Task<CelestialObject?> GetCelestialObject(Guid id)
    {
        throw new NotImplementedException();
    }
}