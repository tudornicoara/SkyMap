using SkyMap.Data;
using SkyMap.Entities;
using SkyMap.Interfaces;

namespace SkyMap.Repositories
{
    public class DiscoverySourceTypeRepository : IDiscoverySourceTypeRepository
    {
        private readonly DataContext _dataContext;

        public DiscoverySourceTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<DiscoverySourceType> AddDiscoverySourceType(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<DiscoverySourceType> GetDiscoverySourceType(Guid id)
        {
            var type = await _dataContext.DiscoverySourceTypes.FindAsync(id);
            return type;
        }

        public Task<List<DiscoverySourceType>> GetDiscoverySourceTypes()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveDiscoverySourceType(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
