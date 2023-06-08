using Microsoft.AspNetCore.Mvc;
using SkyMap.DTOs;
using SkyMap.Entities;
using SkyMap.Interfaces;

namespace SkyMap.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscoverySourceController : ControllerBase
{
    private readonly IDiscoverySourceRepository _discoverySourceRepository;
    private readonly IDiscoverySourceTypeRepository _discoverySourceTypeRepository;

    public DiscoverySourceController(IDiscoverySourceRepository discoverySourceRepository,
        IDiscoverySourceTypeRepository discoverySourceTypeRepository)
    {
        _discoverySourceRepository = discoverySourceRepository;
        _discoverySourceTypeRepository = discoverySourceTypeRepository;
    }

    [HttpPost]
    public async Task<ActionResult<DiscoverySource>> AddDiscoverySource(DiscoverySourceDto discoverySourceDto)
    {
        bool isGuidValid = Guid.TryParse(discoverySourceDto.DiscoverySourceTypeId, out _);

        if (!isGuidValid)
        {
            return BadRequest("This discovery source type id is not a valid guid");
        }

        var existingSource = await _discoverySourceRepository
            .GetDiscoverySourceByName(discoverySourceDto.Name!);

        if (existingSource != null)
        {
            return BadRequest("This discovery source name has already been used");
        }

        var discoverySourceType = await _discoverySourceTypeRepository
                .GetDiscoverySourceType(Guid.Parse(discoverySourceDto.DiscoverySourceTypeId!));

        if (discoverySourceType == null)
        {
            return BadRequest("This discovery source type does not exist");
        }

        var newDiscoverySource = await _discoverySourceRepository.AddDiscoverySource(discoverySourceDto);

        return Ok(newDiscoverySource);
    }

    [HttpGet]
    public async Task<ActionResult<List<DiscoverySource>>> GetDiscoverySources()
    {
        var allSources = await _discoverySourceRepository.GetDiscoverySources();
        return Ok(allSources);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DiscoverySource>> GetDiscoverySource(string id)
    {
        var source = await _discoverySourceRepository.GetDiscoverySource(Guid.Parse(id));

        if (source == null)
        {
            return NotFound();
        }

        return Ok(source);
    }
}