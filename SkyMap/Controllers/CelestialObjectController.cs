using Microsoft.AspNetCore.Mvc;
using SkyMap.DTOs;
using SkyMap.Entities;
using SkyMap.Interfaces;

namespace SkyMap.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CelestialObjectController : ControllerBase
{
    private readonly ICelestialObjectRepository _celestialObjectRepository;
    private readonly ICelestialObjectTypeRepository _celestialObjectTypeRepository;
    private readonly IDiscoverySourceRepository _discoverySourceRepository;

    public CelestialObjectController(ICelestialObjectRepository celestialObjectRepository,
        ICelestialObjectTypeRepository celestialObjectTypeRepository,
        IDiscoverySourceRepository discoverySourceRepository)
    {
        _celestialObjectRepository = celestialObjectRepository;
        _celestialObjectTypeRepository = celestialObjectTypeRepository;
        _discoverySourceRepository = discoverySourceRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<CelestialObject>> AddCelestialObject(CelestialObjectDto celestialObjectDto)
    {
        bool isGuidValid = Guid.TryParse(celestialObjectDto.DiscoverySourceId, out _);
        
        if (!isGuidValid)
        {
            return BadRequest("This discovery source id is not a valid guid");
        }

        if (celestialObjectDto.CelestialObjectTypeId != null)
        {
            isGuidValid = Guid.TryParse(celestialObjectDto.CelestialObjectTypeId, out _);

            if (!isGuidValid)
            {
                return BadRequest("This celestial object type id is not a valid guid");
            }
        }

        var existingObject = await _celestialObjectRepository
            .GetCelestialObjectByName(celestialObjectDto.Name!);

        if (existingObject != null)
        {
            return BadRequest("This celestial object name has already been used");
        }
        
        var discoverySource = await _discoverySourceRepository
            .GetDiscoverySource(Guid.Parse(celestialObjectDto.DiscoverySourceId!));

        if (discoverySource == null)
        {
            return BadRequest("This discovery source does not exist");
        }

        if (celestialObjectDto.CelestialObjectTypeId != null)
        {
            var celestialObjectType = await _celestialObjectTypeRepository
                .GetCelestialObjectType(Guid.Parse(celestialObjectDto.CelestialObjectTypeId));

            if (celestialObjectType == null)
            {
                return BadRequest("This celestial object type does not exist");
            }   
        }

        var newCelestialObject = await _celestialObjectRepository.AddCelestialObject(celestialObjectDto);

        return Ok(newCelestialObject);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<CelestialObject>>> GetCelestialObjects()
    {
        var allObjects = await _celestialObjectRepository.GetCelestialObjects();
        return Ok(allObjects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CelestialObject>> GetCelestialObject(string id)
    {
        var celestialObject = await _celestialObjectRepository.GetCelestialObject(Guid.Parse(id));

        if (celestialObject == null)
        {
            return NotFound();
        }

        return Ok(celestialObject);
    }
}