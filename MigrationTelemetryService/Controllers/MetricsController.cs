using Microsoft.AspNetCore.Mvc;
using MigrationTelemetryService.Models;
using MigrationTelemetryService.Services;

namespace MigrationTelemetryService.Controllers
{
    [ApiController]
    [Route("api/metrics")]
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
    }
}
