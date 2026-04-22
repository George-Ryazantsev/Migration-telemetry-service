using MigrationTelemetryService.Models;

namespace MigrationTelemetryService.Services
{
    public interface IMetricsService
    {
        Task ProcessAsync(MetricDto dto);
    }
}
