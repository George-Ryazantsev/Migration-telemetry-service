namespace MigrationTelemetryService.Models
{
    public class MetricModel
    {
        public string ClientId { get; set; }
        public string EventType { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
