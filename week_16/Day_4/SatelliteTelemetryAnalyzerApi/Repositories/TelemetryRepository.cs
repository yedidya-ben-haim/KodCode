using SatelliteTelemetryAnalyzerApi.Models;

namespace SatelliteTelemetryAnalyzerApi.Repositories
{
    public class TelemetryRepository: ITelemetryRepository
    {
        private readonly List<TelemetryReport> _telemetries = new();
        private int _nextId = 1;

        public async Task<IEnumerable<TelemetryReport>> GetAllAsync()
        {
            await Task.Delay(10);

            return _telemetries;
        }

        public async Task<TelemetryReport?> GetByIdAsync(int id)
        {
            await Task.Delay(10);

            return _telemetries.FirstOrDefault(t => t.Id == id);
        }

        public async Task<IEnumerable<TelemetryReport>> GetBySatelliteIdAsync(int satelliteId)
        {
            await Task.Delay(10);

            return _telemetries.Where(t => t.SatelliteId == satelliteId);
        }

        public async Task<TelemetryReport> CreateAsync(TelemetryReport report)
        {
            await Task.Delay(10);

            report.Id = _nextId++;
            _telemetries.Add(report);
            return report;
        }

    }
}
