using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class WeatherForecastFactory 
    {
        private static readonly string[] Summaries = new[]
        {
            "3Freezing", "3Bracing",// "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        internal static List<WeatherForecastDto> GetForecast(DateTime now, int daysForward)
        {
            var rng = new Random();
            var dates = Enumerable.Range(1, daysForward).Select(d => now.AddDays(d));
            var result = new List<WeatherForecastDto>();
            foreach (var date in dates)
            {
                result.Add( new WeatherForecastDto {
                    Date = date,
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                });
            }
            return result;
        }
    }
}
