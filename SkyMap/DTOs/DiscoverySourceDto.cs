using System.ComponentModel.DataAnnotations;

namespace SkyMap.DTOs;

public class DiscoverySourceDto
{
    [Required]
    public string? Name { get; set; }
    
    [Required]
    public DateTime EstablishmentDate { get; set; }
    
    [Required]
    public string? DiscoverySourceTypeId { get; set; }
    
    [Required]
    public string? StateOwner { get; set; }
}