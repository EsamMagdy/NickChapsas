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

    }
}