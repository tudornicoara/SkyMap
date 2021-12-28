using SkyMap.Entities;

namespace SkyMap.Interfaces
{
    public interface ICelestialObjectTypeRepository
    {
        public Task<CelestialObjectType> AddCelestialObjectType(string name);
        public Task<bool> RemoveCelestialObjectType(Guid id);
        public Task<List<CelestialObjectType>> GetCelestialObjectTypes();
        public Task<CelestialObjectType?> GetCelestialObjectType(Guid id);
    }
}
