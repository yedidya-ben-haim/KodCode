using SatelliteTelemetryAnalyzerApi.Models;

namespace SatelliteTelemetryAnalyzerApi.Repositories;

public interface ITelemetryRepository
{
    Task<IEnumerable<TelemetryReport>> GetAllAsync();
    Task<TelemetryReport> GetByIdAsync(int id);
    Task<IEnumerable<TelemetryReport>> GetBySatelliteIdAsync(int satelliteId);
    Task<TelemetryReport> CreateAsync(TelemetryReport report);
}
