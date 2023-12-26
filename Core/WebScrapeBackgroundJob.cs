namespace HangfireDemo;

public class WebScrapeBackgroundJob
{
    public void Start(string website)
    {
        var scrapper = new MyWebScraper(website);
        scrapper.Init();
        scrapper.Start();
    }
}