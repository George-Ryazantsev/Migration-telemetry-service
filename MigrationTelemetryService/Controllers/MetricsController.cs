using Microsoft.AspNetCore.Mvc;
using MigrationTelemetryService.Models;
using System.Diagnostics;

namespace MigrationTelemetryService.Controllers
{
    [ApiController]
    [Route("api/metrics")]
    public class MetricsController : Controller
    {
        private static readonly List<MetricDto> _storage = new();

        [HttpPost]
        public IActionResult Post([FromBody] MetricDto metric)
        {
            _storage.Add(metric);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_storage);
        }
    }
}
