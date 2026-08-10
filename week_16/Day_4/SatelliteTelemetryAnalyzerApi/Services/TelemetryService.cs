using SatelliteTelemetryAnalyzerApi.Models;
using SatelliteTelemetryAnalyzerApi.Repositories;

namespace SatelliteTelemetryAnalyzerApi.Services;

public class TelemetryService : ITelemetryService
{
    private readonly ISatelliteRepository _satelliteRepository;
    private readonly ITelemetryRepository _telemetryRepository;

    public TelemetryService(ISatelliteRepository satelliteRepository,
                            ITelemetryRepository telemetryRepository)
    {
        _satelliteRepository = satelliteRepository;
        _telemetryRepository = telemetryRepository;
    }

    public async Task<IEnumerable<TelemetryReport>> GetAllReportsAsync()
    {
        return await _telemetryRepository.GetAllAsync();
    }

    public async Task<TelemetryReport?> GetReportByIdAsync(int id)
    {
        return await _telemetryRepository.GetByIdAsync(id);
    }

    public async Task<TelemetryReport?> SubmitTelemetryAsync(SubmitTelemetryRequest request)
    {
        // 1. Get the satellite by ID.
        var satellite = await _satelliteRepository.GetByIdAsync(request.SatelliteId);

        if (satellite == null)
        {
            return null;
        }

        // 2. Check critical conditions
        if (request.BatteryPercent < 10)
        {
            return null;
        }
        if (request.TemperatureCelsius < -50 || request.TemperatureCelsius > 60)
        {
            return null;
        }
        if (request.SignalStrengthDb < -100)
        {
            return null;
        }

        var telemetryReport = new TelemetryReport
        {
            SatelliteId = request.SatelliteId,
            BatteryPercent = request.BatteryPercent,
            TemperatureCelsius = request.TemperatureCelsius,
            SignalStrengthDb = request.SignalStrengthDb,
            ReportedAt = DateTime.Now,
            Status = "Normal"
        };

        await _telemetryRepository.CreateAsync(telemetryReport);

        return telemetryReport;
    }
}
