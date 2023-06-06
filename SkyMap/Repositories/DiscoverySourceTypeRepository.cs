using Microsoft.EntityFrameworkCore;
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

        public async Task<DiscoverySourceType> AddDiscoverySourceType(string name)
        {
            DiscoverySourceType type = new()
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            await _dataContext.DiscoverySourceTypes.AddAsync(type);
            await _dataContext.SaveChangesAsync();
            return type;
        }

        public async Task<DiscoverySourceType?> GetDiscoverySourceType(Guid id)
        {
            var type = await _dataContext.DiscoverySourceTypes.FindAsync(id);
            return type;
        }

        public async Task<DiscoverySourceType?> GetDiscoverySourceTypeByName(string name)
        {
            var type = await _dataContext.DiscoverySourceTypes
                .FirstOrDefaultAsync(t => t.Name == name);

            return type;
        }

        public async Task<List<DiscoverySourceType>> GetDiscoverySourceTypes()
        {
            var types = await _dataContext.DiscoverySourceTypes.ToListAsync();
            return types;
        }

        public async Task<bool> RemoveDiscoverySourceType(Guid id)
        {
            var type = await _dataContext.DiscoverySourceTypes.FindAsync(id);
            if (type == null)
            {
                return false;
            }

            _dataContext.DiscoverySourceTypes.Remove(type);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
