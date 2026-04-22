using Microsoft.AspNetCore.Mvc;
using MigrationTelemetryService.Models;
using MigrationTelemetryService.Services;

namespace MigrationTelemetryService.Controllers
{
    [ApiController]
    [Route("api/metrics")]
    public class MetricsController : Controller
    {
        private readonly IMetricsService _service;
        public MetricsController(IMetricsService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MetricDto dto)
        {
            await _service.ProcessAsync(dto);
            return Ok();
        }
    }
}
