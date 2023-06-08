using Microsoft.AspNetCore.Mvc;
using SkyMap.Entities;
using SkyMap.Interfaces;

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

    [HttpPost("{name}")]
    public async Task<ActionResult<CelestialObjectType>> AddCelestialObjectType(string name)
    {
        var allTypes = await _celestialObjectTypeRepository.GetCelestialObjectTypes();

        var existingType = allTypes.FirstOrDefault(t => t.Name == name);
        if (existingType != null)
        {
            return BadRequest("This type name has already been used");
        }

        var newType = await _celestialObjectTypeRepository.AddCelestialObjectType(name);

        return Ok(newType);
    }

    [HttpGet]
    public async Task<ActionResult<List<CelestialObjectType>>> GetCelestialObjectTypes()
    {
        var allTypes = await _celestialObjectTypeRepository.GetCelestialObjectTypes();

        return Ok(allTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CelestialObjectType>> GetCelestialObjectType(string id)
    {
        var type = await _celestialObjectTypeRepository.GetCelestialObjectType(Guid.Parse(id));

        if (type == null)
        {
            return NotFound();
        }

        return Ok(type);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<CelestialObjectType>> RemoveCelestialObjectType(string id)
    {
        var type = await _celestialObjectTypeRepository.GetCelestialObjectType(Guid.Parse(id));

        if (type == null)
        {
            return NotFound();
        }

        await _celestialObjectTypeRepository.RemoveCelestialObjectType(Guid.Parse(id));
        return Ok();
    }
}
