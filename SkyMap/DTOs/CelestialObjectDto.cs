using System.ComponentModel.DataAnnotations;

namespace SkyMap.DTOs;

public class CelestialObjectDto
{
    [Required]
    public string? Mass { get; set; }
    
    [Required]
    public string? EquatorialDiameter { get; set; }
    
    [Required]
    public string? SurfaceTemperature { get; set; }
    
    [Required]
    public DateTime DiscoveryDate { get; set; }
    
    [Required]
    public Guid DiscoverySourceId { get; set; }
    
    public Guid? CelestialObjectTypeId { get; set; }
}