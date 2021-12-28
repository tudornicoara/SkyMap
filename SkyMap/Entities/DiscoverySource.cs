namespace SkyMap.Entities;

public class DiscoverySource
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public DateTime EstablishmentDate { get; set; }

    public Guid DiscoverySourceTypeId { get; set; }
    public DiscoverySourceType? Type { get; set; }
    
    public string? StateOwner { get; set; }
}