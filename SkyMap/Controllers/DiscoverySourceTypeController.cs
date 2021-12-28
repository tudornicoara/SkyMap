using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyMap.Data;
using SkyMap.Entities;

namespace SkyMap.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscoverySourceTypeController : ControllerBase
{
    private readonly DataContext _dataContext;

    public DiscoverySourceTypeController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpPost("add/{name}")]
    public async Task<ActionResult<DiscoverySourceType>> AddDiscoverySourceType(string name)
    {
        var allTypes = _dataContext.DiscoverySourceTypes.ToList();

        var existingType = allTypes.FirstOrDefault(t => t.Name == name);
        if (existingType != null)
        {
            return BadRequest("This type is already inserted");
        }

        DiscoverySourceType discoverySourceType = new();
        discoverySourceType.Id = Guid.NewGuid();
        discoverySourceType.Name = name;
        
        await _dataContext.DiscoverySourceTypes.AddAsync(discoverySourceType);
        await _dataContext.SaveChangesAsync();

        return Ok(discoverySourceType);
    }

    [HttpGet("types")]
    public async Task<ActionResult<List<DiscoverySourceType>>> GetDiscoverySourceTypes()
    {
        var allTypes = await _dataContext.DiscoverySourceTypes.ToListAsync();

        return Ok(allTypes);
    }

    [HttpGet("type/{id}")]
    public async Task<ActionResult<DiscoverySourceType>> GetDiscoverySourceType(string id)
    {
        var type = await _dataContext.DiscoverySourceTypes.FindAsync(Guid.Parse(id));

        if (type == null)
        {
            return NotFound();
        }

        return Ok(type);
    }
}
