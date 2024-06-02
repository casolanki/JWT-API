using API.controllers;

namespace API.Controllers
{

    // [ApiController]
    // [Route("[controller]")]
     [Authorize]
    public class WeatherForecastController : BaseApiController
    {
         private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summarysss = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

}