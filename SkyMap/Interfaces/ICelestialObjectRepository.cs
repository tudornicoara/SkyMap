using SkyMap.DTOs;
using SkyMap.Entities;

namespace SkyMap.Interfaces;

public interface ICelestialObjectRepository
{
    public Task<CelestialObject> AddCelestialObject(CelestialObjectDto celestialObjectDto);
    public Task<bool> RemoveCelestialObject(Guid id);
    public Task<List<CelestialObject>> GetCelestialObjects();
    public Task<CelestialObject?> GetCelestialObject(Guid id);
}