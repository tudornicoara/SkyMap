using SkyMap.Entities;

namespace SkyMap.Interfaces
{
    public interface IDiscoverySourceTypeRepository
    {
        public Task<DiscoverySourceType> AddDiscoverySourceType(string name);
        public Task<bool> RemoveDiscoverySourceType(Guid id);
        public Task<List<DiscoverySourceType>> GetDiscoverySourceTypes();
        public Task<DiscoverySourceType?> GetDiscoverySourceType(Guid id);
        public Task<DiscoverySourceType?> GetDiscoverySourceTypeByName(string name);
    }
}
