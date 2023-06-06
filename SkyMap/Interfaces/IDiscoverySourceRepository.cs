using SkyMap.DTOs;
using SkyMap.Entities;

namespace SkyMap.Interfaces
{
    public interface IDiscoverySourceRepository
    {
        public Task<DiscoverySource> AddDiscoverySource(DiscoverySourceDto discoverySourceDto);
        public Task<bool> RemoveDiscoverySource(Guid id);
        public Task<List<DiscoverySource>> GetDiscoverySources();
        public Task<DiscoverySource?> GetDiscoverySource(Guid id);
        public Task<DiscoverySource?> GetDiscoverySourceByName(string name);
    }
}
