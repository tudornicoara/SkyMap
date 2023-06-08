using Microsoft.EntityFrameworkCore;
using SkyMap.Data;
using SkyMap.DTOs;
using SkyMap.Entities;
using SkyMap.Interfaces;

namespace SkyMap.Repositories;

public class DiscoverySourceRepository : IDiscoverySourceRepository
{
    private readonly DataContext _dataContext;

    public DiscoverySourceRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<DiscoverySource> AddDiscoverySource(DiscoverySourceDto discoverySourceDto)
    {
        var discoverySource = new DiscoverySource
        {
            Id = Guid.NewGuid(),
            Name = discoverySourceDto.Name,
            EstablishmentDate = discoverySourceDto.EstablishmentDate,
            DiscoverySourceTypeId = Guid.Parse(discoverySourceDto.DiscoverySourceTypeId!),
            StateOwner = discoverySourceDto.StateOwner
        };

        await _dataContext.DiscoverySources.AddAsync(discoverySource);
        await _dataContext.SaveChangesAsync();
        return discoverySource;
    }

    public async Task<bool> RemoveDiscoverySource(Guid id)
    {
        var discoverySource = await _dataContext.DiscoverySources.FindAsync(id);
        if (discoverySource == null)
        {
            return false;
        }

        _dataContext.DiscoverySources.Remove(discoverySource);
        await _dataContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<DiscoverySource>> GetDiscoverySources()
    {
        var discoverySources = await _dataContext.DiscoverySources
            .Include(x => x.Type)
            .ToListAsync();
        return discoverySources;
    }

    public async Task<DiscoverySource?> GetDiscoverySource(Guid id)
    {
        var discoverySource = await _dataContext.DiscoverySources
            .Include(x => x.Type)
            .FirstOrDefaultAsync(x => x.Id == id);
        return discoverySource;
    }

    public async Task<DiscoverySource?> GetDiscoverySourceByName(string name)
    {
        var discoverySource = await _dataContext.DiscoverySources
            .Include(x => x.Type)
            .FirstOrDefaultAsync(d => d.Name == name);

        return discoverySource;
    }
}