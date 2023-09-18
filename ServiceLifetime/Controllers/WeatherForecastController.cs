using Microsoft.AspNetCore.Mvc;

namespace ServiceLifetime.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ISingletonService _singletonService;
        private readonly ISingletonService _singletonService2;

        private readonly IScopedService _scopedService;
        private readonly IScopedService _scopedService2;

        private readonly ITransientService _transientService;
        private readonly ITransientService _transientService2;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            ISingletonService singletonService, 
            IScopedService scopedService, 
            ITransientService transientService, 
            IScopedService scopedService2, 
            ISingletonService singletonService2, 
            ITransientService transientService2)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
            _logger = logger;
            _scopedService2 = scopedService2;
            _singletonService2 = singletonService2;
            _transientService2 = transientService2;
        }


        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;



        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("FirstRequest")]
        public Response FirstRequest(string name)
        {
            var singletonName = _singletonService.GetName(name);
            var singletonName2 = _singletonService2.GetName(name);

            var scopedName = _scopedService.GetName(name);
            var scopedName2 = _scopedService2.GetName(name);

            var transientName = _transientService.GetName(name);
            var transientName2 = _transientService2.GetName(name);

            return new Response
            {
                SingletonResponse = new SingletonResponse
                {
                    FirstSingletonName = singletonName, // First Initial
                    SecondSingletonName = singletonName2, // Initial Before
                },
                ScopedResponse = new ScopedResponse
                {
                    FirstScopedName = scopedName, // First Initial 
                    SecondScopedName = scopedName2 // Initial Before
                },
                TransientResponse = new TransientResponse
                {
                    FirstTransientName = transientName, // First Initial
                    SecondTransientName = transientName2 // First Initial
                }
            };

        }
        [HttpGet("SecondRequest")]
        public Response SecondRequest(string name)
        {
            var singletonName = _singletonService.GetName(name);
            var singletonName2 = _singletonService2.GetName(name);

            var scopedName = _scopedService.GetName(name);
            var scopedName2 = _scopedService2.GetName(name);

            var transientName = _transientService.GetName(name);
            var transientName2 = _transientService2.GetName(name);


            return new Response
            {
                SingletonResponse = new SingletonResponse
                {
                    FirstSingletonName = singletonName, // Initial Before
                    SecondSingletonName = singletonName2, // Initial Before
                },
                ScopedResponse = new ScopedResponse
                {
                    FirstScopedName = scopedName, // First Initial 
                    SecondScopedName = scopedName2 // Initial Before
                },
                TransientResponse = new TransientResponse
                {
                    FirstTransientName = transientName, // First Initial
                    SecondTransientName = transientName2 // First Initial
                }
            };
        }

    }
}

public class Response
{
    public SingletonResponse SingletonResponse { get; set; }
    public TransientResponse TransientResponse { get; set; }
    public ScopedResponse ScopedResponse { get; set; }
}
public class SingletonResponse
{
    public string FirstSingletonName { get; set; }
    public string SecondSingletonName { get; set; }
}
public class TransientResponse
{
    public string FirstTransientName { get; set; }
    public string SecondTransientName { get; set; }
}
public class ScopedResponse
{
    public string FirstScopedName { get; set; }
    public string SecondScopedName { get; set; }
}