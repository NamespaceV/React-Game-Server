using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly string _config;

        public WeatherForecastController(IConfiguration config)
        {
            _config = string.Join("\n", config.GetChildren().Select(c => c.Key + "=>" + c.Value));
        }

        [HttpGet]
        public IEnumerable<WeatherForecastDto> Get()
        {
            var forecast = WeatherForecastFactory.GetForecast(DateTime.Now, 5);
            forecast[0].Summary = _config;
            return forecast;
        }
    }
}
