namespace SkyMap.Entities;

public class CelestialObject
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Mass { get; set; }
    public string? EquatorialDiameter { get; set; }
    public string? SurfaceTemperature { get; set; }
    public DateTime DiscoveryDate { get; set; }

    public Guid DiscoverySourceId { get; set; }
    public DiscoverySource? DiscoverySource { get; set; }

    public Guid? CelestialObjectTypeId { get; set; }
    public CelestialObjectType? Type { get; set; }
}
