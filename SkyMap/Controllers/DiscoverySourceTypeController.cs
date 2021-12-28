using Microsoft.AspNetCore.Mvc;
using SkyMap.Entities;
using SkyMap.Interfaces;

namespace SkyMap.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscoverySourceTypeController : ControllerBase
{
    private readonly IDiscoverySourceTypeRepository _discoverySourceTypeRepository;

    public DiscoverySourceTypeController(IDiscoverySourceTypeRepository discoverySourceTypeRepository)
    {
        _discoverySourceTypeRepository = discoverySourceTypeRepository;
    }

    [HttpPost("add/{name}")]
    public async Task<ActionResult<DiscoverySourceType>> AddDiscoverySourceType(string name)
    {
        var allTypes = await _discoverySourceTypeRepository.GetDiscoverySourceTypes();

        var existingType = allTypes.FirstOrDefault(t => t.Name == name);
        if (existingType != null)
        {
            return BadRequest("This type is already inserted");
        }

        var newType = await _discoverySourceTypeRepository.AddDiscoverySourceType(name);

        return Ok(newType);
    }

    [HttpGet("types")]
    public async Task<ActionResult<List<DiscoverySourceType>>> GetDiscoverySourceTypes()
    {
        var allTypes = await _discoverySourceTypeRepository.GetDiscoverySourceTypes();

        return Ok(allTypes);
    }

    [HttpGet("type/{id}")]
    public async Task<ActionResult<DiscoverySourceType>> GetDiscoverySourceType(string id)
    {
        var type = await _discoverySourceTypeRepository.GetDiscoverySourceType(Guid.Parse(id));

        if (type == null)
        {
            return NotFound();
        }

        return Ok(type);
    }
}
