using IronWebScraper;

public class MyWebScraper : WebScraper
{
    private readonly string _website;

    public MyWebScraper(string website)
    {
        _website = website;
    }
    /// <summary>
    /// Override this method initialize your web-scraper.
    /// Important tasks will be to Request at least one start url... and set allowed/banned domain or url patterns.
    /// </summary>
    public override void Init()
    {
        //License.LicenseKey = "LicenseKey"; // Write License Key
        this.LoggingLevel = WebScraper.LogLevel.All; // All Events Are Logged
        this.Request(_website, Parse);
    }

    /// <summary>
    /// Override this method to create the default Response handler for your web scraper.
    /// </summary>
    /// <param name="response">The http Response object to parse</param>
    public override void Parse(Response response)
    {
        // set working directory for the project
        WorkingDirectory = AppContext.BaseDirectory + @"WebScraping\Output\";
        Console.WriteLine(AppContext.BaseDirectory + @"WebScraping\Output\");

        for (int i = 0; i < 5; i++)
        {
            var header = "h" + i;
            foreach (var title_link in response.Css(header))
            {
                // Read Link Text
                string strTitle = title_link.TextContentClean;
                // Save Result to File
                Scrape(new ScrapedData() { { "Title", strTitle } }, header+".json");
            }
        }
    }
}