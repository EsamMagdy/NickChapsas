using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlagExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFeatureManager featureManager)
        {
            _logger = logger;
            _featureManager = featureManager;
        }

        [HttpGet("GetCustomerNameWithTimeWindowFilter")]
        public async Task<string> GetCustomerNameWithTimeWindowFilter()
        {
            var currentDateTime = DateTime.UtcNow.ToString("O");
            if (await _featureManager.IsEnabledAsync("Percentage"))
            {
                return $"Esam {currentDateTime}";
            }
            else
            {
                return $"No Name {currentDateTime}";
            }

        }
        [HttpGet("GetCustomerName")]
        public async Task<string> GetCustomerName()
        {
            if (await _featureManager.IsEnabledAsync("NewFeatureFlag"))
            {
                return "Esam";
            }
            else
            {
                return "No Name";
            }

        }

        [FeatureGate("NewFeatureFlag")] // if NewFeatureFlag is true it will enter to action if not it will return 404 Not Found

        [HttpGet("GetCustomerNameForTest")]
        public async Task<string> GetCustomerNameForTest()
        {
            return "GetCustomerNameForTest";
        }


        [HttpGet("GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast()
        {
            if (await _featureManager.IsEnabledAsync("NewFeatureFlag"))
            {
                return new List<WeatherForecast>();
            }
            else
            {
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray();
            }

        }


        [HttpGet("TestPercentageFilter")]
        [FeatureGate("NewPercentageFilter")]
        public async Task<string> TestPercentageFilter()
        {
            var newAlgorithm = await _featureManager.IsEnabledAsync("NewPercentageFilter");
            return newAlgorithm ? "A" : "B";
        }


        [HttpGet("ExcuteOnEdgeOnly")]
        [FeatureGate("BrowserFlag")]
        public async Task<ActionResult> ExcuteOnEdgeOnly()
        {
            return Ok("this code will be executed in microsoft edge");
        }



    }
}