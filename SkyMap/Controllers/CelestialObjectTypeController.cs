using Microsoft.AspNetCore.Mvc;
using SkyMap.Entities;
using SkyMap.Interfaces;
using SkyMap.Repositories;

namespace SkyMap.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CelestialObjectTypeController : ControllerBase
{
    private readonly ICelestialObjectTypeRepository _celestialObjectTypeRepository;
    
    public CelestialObjectTypeController(ICelestialObjectTypeRepository celestialObjectTypeRepository)
    {
        _celestialObjectTypeRepository = celestialObjectTypeRepository;
    }

    [HttpPost("add/{name}")]
    public async Task<ActionResult<CelestialObjectType>> AddCelestialObjectType(string name)
    {
        var allTypes = await _celestialObjectTypeRepository.GetCelestialObjectTypes();

        var existingType = allTypes.FirstOrDefault(t => t.Name == name);
        if (existingType != null)
        {
            return BadRequest("This type is already inserted");
        }

        var newType = await _celestialObjectTypeRepository.AddCelestialObjectType(name);

        return Ok(newType);
    }

    [HttpGet("types")]
    public async Task<ActionResult<List<CelestialObjectType>>> GetCelestialObjectTypes()
    {
        var allTypes = await _celestialObjectTypeRepository.GetCelestialObjectTypes();

        return Ok(allTypes);
    }

    [HttpGet("type/{id}")]
    public async Task<ActionResult<CelestialObjectType>> GetCelestialObjectType(string id)
    {
        var type = await _celestialObjectTypeRepository.GetCelestialObjectType(Guid.Parse(id));

        if (type == null)
        {
            return NotFound();
        }

        return Ok(type);
    }
}
