using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWebAPI_Course
{
    public interface IWeatherForcastService
    {
        IEnumerable<WeatherForecast> Get(int numOfResults, int minTemp, int maxTemp);
    }
}
