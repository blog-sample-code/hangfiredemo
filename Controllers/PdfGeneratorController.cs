using Hangfire;
using HangfireDemo.Core;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class PdfGeneratorController : ControllerBase
{
    [HttpGet("request", Name = "Start pdf Generation")]
    public void Start([FromQuery] string websiteUrl)
    {
        BackgroundJob.Enqueue<PdfGenerationJob>(x => x.Start(websiteUrl));
    }

    [HttpGet("result", Name = "Download pdf Generation")]
    public IActionResult WebResult()
    {
        var filePath = AppContext.BaseDirectory + "result.pdf";

        var stream = new FileStream(filePath, FileMode.Open);
        //return new FileStreamResult(stream, "application/pdf");   
       // return new PhysicalFileResult(filePath, "application/pdf");
       return new FileStreamResult(stream, "application/octet-stream") { FileDownloadName = "website.pdf" };
    }
}