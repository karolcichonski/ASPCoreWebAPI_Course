using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWebAPI_Course.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromQuery]int numOfResults, [FromQuery]int minTemp, [FromQuery]int maxTemp)
        {
            var rng = new Random();
            return Enumerable.Range(1, numOfResults).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(minTemp, maxTemp),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("generate")]
        public ActionResult Generator([FromQuery] int numOfResults, [FromBody] TemperatureRequest Temp)
        {

            if(numOfResults>=0 & Temp.maxTemp > Temp.minTemp)
            {
                var res = Get(numOfResults, Temp.minTemp, Temp.maxTemp);
                return Ok(res);

            }
            else
            {
                return StatusCode(400);
            }


        }

    }
}
