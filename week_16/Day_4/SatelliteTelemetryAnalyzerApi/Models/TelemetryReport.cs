using System.ComponentModel.DataAnnotations;

namespace SatelliteTelemetryAnalyzerApi.Models;

public class TelemetryReport
{
    public int Id { get; set; }

    [Required]
    public int SatelliteId { get; set; }

    [Required]
    [Range(0, 100)]
    public double BatteryPercent { get; set; }

    [Required]
    [Range(-100, 100)]
    public double TemperatureCelsius { get; set; }

    [Required]
    [Range(-120, 100)]
    public double SignalStrengthDb { get; set; }

    public DateTime? ReportedAt { get; set; }

    public string? Status { get; set; } = "Normal";
}
