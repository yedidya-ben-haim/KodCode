using System.ComponentModel.DataAnnotations;

namespace SatelliteTelemetryAnalyzerApi.Models;

public class Satellite
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(200, 40000)]
    public double OrbitAltitudeKm { get; set; }

    [Required]
    [EnumDataType(typeof(SatellitesStatusType))]
    public SatellitesStatusType Status { get; set; }
}

public enum SatellitesStatusType
{
    Active,
    Standby,
    Decommissioned
}
