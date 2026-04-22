using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MigrationTelemetryService.Repository
{    
    public class Metric
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string ClientId { get; set; }
        public string EventType { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
