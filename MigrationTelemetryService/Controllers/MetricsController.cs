using Microsoft.AspNetCore.Mvc;
using MigrationTelemetryService.Models;
using MigrationTelemetryService.Services;

namespace MigrationTelemetryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetricsController : Controller
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

        [HttpGet("{series}/{number}")]
        public async Task<IActionResult> Post(string series, string number)
        {
            MetricDto metricDto = new()
            {
                ClientId = series,
                Timestamp = DateTime.Now,
                EventType = number
            };

            await _metricsService.ProcessAsync(metricDto);
            return Ok();
        }
    }
}
