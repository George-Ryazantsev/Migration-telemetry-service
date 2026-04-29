namespace MigrationTelemetryService.Repository
{
    public interface IMetricsRepository
    {
        Task InsertAsync(Metric metric);
    }
}
