using System.Net.Http.Json;

namespace MetricsClientSimulator
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            for (int i = 0; i < 5; i++)
            {
                var metric = new
                {
                    ClientId = $"client-{i}",
                    EventType = i % 2 == 0 ? "migration_started" : "migration_completed",
                    Timestamp = DateTime.UtcNow
                };

                var response = await client.PostAsJsonAsync("https://localhost:7122/api/metrics", metric);

                Console.WriteLine($"Status: {response.StatusCode}");
                await Task.Delay(1000);
            }
        }
    }
}