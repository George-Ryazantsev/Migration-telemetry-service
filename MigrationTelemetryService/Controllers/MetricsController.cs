using Microsoft.AspNetCore.Mvc;
using MigrationTelemetryService.Models;
using MigrationTelemetryService.Services;

namespace MigrationTelemetryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetricsController : ControllerBase
    {
        private readonly IMetricsService _metricsService;

        public MetricsController(IMetricsService service)
        {
            _metricsService = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MetricDto dto)
        {
            await _metricsService.ProcessAsync(dto);
            return Ok();
        }

        [HttpGet("{clientId}/{eventType}")]
        public async Task<IActionResult> Post(string clientId, string eventType)
        {
            MetricDto metricDto = new()
            {
                ClientId = clientId,
                Timestamp = DateTime.Now,
                EventType = eventType
            };

            await _metricsService.ProcessAsync(metricDto);
            return Ok();
        }
    }
}
