namespace HangfireDemo.Core;

public class PdfGenerationJob
{
    public void Start(string website)
    {
        // Create a PDF from any existing web page
        ChromePdfRenderer renderer = new ChromePdfRenderer();
        PdfDocument pdf = renderer.RenderUrlAsPdf(website);

        var filePath = AppContext.BaseDirectory + "result.pdf";
        pdf.SaveAs(filePath);
    }
}