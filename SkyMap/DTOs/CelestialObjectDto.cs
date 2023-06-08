using System.ComponentModel.DataAnnotations;

namespace SkyMap.DTOs;

public class CelestialObjectDto
{
    [Required]
    public string? Name { get; set; }
    
    [Required]
    public string? Mass { get; set; }
    
    [Required]
    public string? EquatorialDiameter { get; set; }
    
    [Required]
    public string? SurfaceTemperature { get; set; }
    
    [Required]
    public DateTime DiscoveryDate { get; set; }
    
    [Required]
    public string? DiscoverySourceId { get; set; }
    
    public string? CelestialObjectTypeId { get; set; }
}