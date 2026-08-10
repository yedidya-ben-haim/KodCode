using SatelliteTelemetryAnalyzerApi.Models;

namespace SatelliteTelemetryAnalyzerApi.Repositories;

public class SatelliteRepository : ISatelliteRepository
{
    private readonly List<Satellite> _satellites;
    private int _nextId;

    public SatelliteRepository()
    {
        _nextId = 6;

        _satellites = new List<Satellite>
        {
                     new Satellite
            {
                Id = 1,
                Name = "Horizon-1",
                OrbitAltitudeKm = 550,
                Status = SatellitesStatusType.Active
            },
            new Satellite
            {
                Id = 2,
                Name = "SkyWatch-2",
                OrbitAltitudeKm = 720,
                Status = SatellitesStatusType.Standby
            },
            new Satellite
            {
                Id = 3,
                Name = "OrbitGuard-3",
                OrbitAltitudeKm = 1200,
                Status = SatellitesStatusType.Active
            },
            new Satellite
            {
                Id = 4,
                Name = "DeepSpace-4",
                OrbitAltitudeKm = 36000,
                Status = SatellitesStatusType.Active
            },
            new Satellite
            {
                Id = 5,
                Name = "SignalEye-5",
                OrbitAltitudeKm = 850,
                Status = SatellitesStatusType.Decommissioned
            }
        };
    }

    public async Task<IEnumerable<Satellite>> GetAllAsync()
    {
        await Task.Delay(10);
        return _satellites;
    }

    public async Task<Satellite?> GetByIdAsync(int id)
    {
        await Task.Delay(10);
        return _satellites.FirstOrDefault(s => s.Id == id);
    }

    public async Task<Satellite> CreateAsync(Satellite satellite)
    {
        satellite.Id = _nextId;
        _nextId++;

        await Task.Delay(10);

        _satellites.Add(satellite);

        return satellite;
    }

    public async Task<Satellite?> UpdateAsync(int id, Satellite satellite)
    {
        await Task.Delay(10);

        var existing = _satellites.FirstOrDefault(s => s.Id == id);

        if (existing == null)
        {
            return null;
        }

        existing.Name = satellite.Name;
        existing.OrbitAltitudeKm = satellite.OrbitAltitudeKm;
        existing.Status = satellite.Status;

        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await Task.Delay(10);

        var satellite = _satellites.FirstOrDefault(s => s.Id == id);

        if (satellite == null)
        {
            return false;
        }

        _satellites.Remove(satellite);
        return true;
    }
}
