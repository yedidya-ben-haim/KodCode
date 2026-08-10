using SatelliteTelemetryAnalyzerApi.Models;

namespace SatelliteTelemetryAnalyzerApi.Repositories;

public interface ISatelliteRepository
{
    Task<IEnumerable<Satellite>> GetAllAsync();
    Task<Satellite?> GetByIdAsync(int id);
    Task<Satellite> CreateAsync(Satellite satellite);
    Task<Satellite?> UpdateAsync(int id, Satellite satellite);
    Task<bool> DeleteAsync(int id);
}
