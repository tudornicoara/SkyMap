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

    [HttpPost("{name}")]
    public async Task<ActionResult<DiscoverySourceType>> AddDiscoverySourceType(string name)
    {
        var existingType = await _discoverySourceTypeRepository.GetDiscoverySourceTypeByName(name);
        if (existingType != null)
        {
            return BadRequest("This type name has already been used");
        }

        var newType = await _discoverySourceTypeRepository.AddDiscoverySourceType(name);

        return Ok(newType);
    }

    [HttpGet]
    public async Task<ActionResult<List<DiscoverySourceType>>> GetDiscoverySourceTypes()
    {
        var allTypes = await _discoverySourceTypeRepository.GetDiscoverySourceTypes();

        return Ok(allTypes);
    }

    [HttpGet("{id}")]
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
