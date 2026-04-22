
using MongoDB.Driver;

namespace MigrationTelemetryService.Repository
{
    public class MetricsRepository : IMetricsRepository
    {        
        private readonly IMongoCollection<Metric> _collection;

        public MetricsRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Metric>("Metrics");
        }

        public async Task InsertAsync(Metric metric)
        {
            await _collection.InsertOneAsync(metric);
        }
    }
}
