using DragAndDropExample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComponentLibrary.Models;

namespace DragAndDropExample.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Generate random event data
        /// </summary>
        /// <param name="dates"></param>
        /// <returns></returns>
        [HttpPost]
        public List<CalendarItem<string>> GetDates(DateChangedEvent dates)
        {
            var random = new Random();
            int r = random.Next(50);
            var dataSource = new List<CalendarItem<string>>();
            for (int i = 0; i < r; i++)
            {
                dataSource.Add(new CalendarItem<string> { Date = dates.StartDate.AddDays(random.Next(41)), Item = string.Format("Event {0}", i) });
            }
            return dataSource;
        }
    }
}
