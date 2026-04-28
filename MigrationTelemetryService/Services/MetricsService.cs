// Ignore Spelling: dto

using MigrationTelemetryService.Models;
using MigrationTelemetryService.Repository;

namespace MigrationTelemetryService.Services
{
    public class MetricsService : IMetricsService
    {
        private readonly IMetricsRepository _repository;

        public MetricsService(IMetricsRepository repository)
        {
            _repository = repository;
        }

        public async Task ProcessAsync(MetricDto dto)
        {            
            if (string.IsNullOrWhiteSpace(dto.ClientId))
                throw new ArgumentException("ClientId is required");

            var metric = new Metric
            {
                ClientId = dto.ClientId,
                EventType = dto.EventType,
                Timestamp = dto.Timestamp == default
                    ? DateTime.UtcNow
                    : dto.Timestamp
            };

            await _repository.InsertAsync(metric);
        }
    }
}
