using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
        }

        [HttpGet]
        public IEnumerable<WeatherForecastDto> Get()
        {
            return WeatherForecastFactory.GetForecast(DateTime.Now, 5);
        }
    }
}
