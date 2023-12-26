using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class ScraperController : ControllerBase
{
    [HttpGet("request", Name = "Website scrapper")]
    public void StartWebScrapping([FromQuery] string websiteUrl)
    {
        BackgroundJob.Enqueue<WebScrapeBackgroundJob>(x => x.Start(websiteUrl));
    }

    [HttpGet("result", Name = "Website scrapper response")]
    public List<string> WebResult()
    {
        var dir = AppContext.BaseDirectory + @"WebScraping\Output\";
        var files = Directory.EnumerateFiles(dir);
        var result = new List<string>();
        foreach (var file in files)
        {
            var lines = System.IO.File.ReadLines(file);
            foreach (var line in lines)
            {
                result.Add(
                    $"{file.Split("\\").Last().Split(".").First()}-  {line.Split(":").Last().Replace("\"", "").Replace("}", "")}");
            }
        }

        return result;
    }
}