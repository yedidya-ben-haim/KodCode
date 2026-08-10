using System.ComponentModel.DataAnnotations;

namespace SatelliteTelemetryAnalyzerApi.Models;

public class SubmitTelemetryRequest
{
    [Required]
    public int SatelliteId { get; set; }

    [Required]
    [Range(0, 100)]
    public double BatteryPercent { get; set; }

    [Required]
    [Range(-120, 0)]
    public double TemperatureCelsius { get; set; }

    [Required]
    [Range(-100, 100)]
    public double SignalStrengthDb { get; set; }
}
