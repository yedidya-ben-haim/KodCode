using SatelliteTelemetryAnalyzerApi.Models;

namespace SatelliteTelemetryAnalyzerApi.Services;

public interface ITelemetryService
{
    Task<IEnumerable<TelemetryReport>> GetAllReportsAsync();
    Task<TelemetryReport?> GetReportByIdAsync(int id);
    Task<TelemetryReport> SubmitTelemetryAsync(SubmitTelemetryRequest request);
}
