using System.Text.Json;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HangfireDemo.Controllers;

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

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        // Enqueue a job to run immediately
        BackgroundJob.Enqueue<MyBackgroundJob>(x => x.ProcessJobNoDelay());

// Schedule a job to run after a delay
        BackgroundJob.Schedule<MyBackgroundJob>(x => x.ProcessJob(), TimeSpan.FromMinutes(5));

// Schedule a recurring job
        RecurringJob.AddOrUpdate<MyBackgroundJob>("jobId", x => x.ProcessJob(), Cron.Daily);


        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}