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

        private readonly IWeatherForcastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForcastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromQuery]int numOfResults, [FromQuery]int minTemp, [FromQuery]int maxTemp)
        {
            var result = _service.Get(numOfResults, minTemp, maxTemp);
            return result;
        }

        [HttpPost]
        [Route("generate")]
        public ActionResult Generator([FromQuery] int numOfResults, [FromBody] TemperatureRequest Temp)
        {

            if(numOfResults>0 & Temp.maxTemp > Temp.minTemp)
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
