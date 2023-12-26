namespace HangfireDemo;

public class MyBackgroundJob
{
    public void ProcessJob()
    {
        // Your background job logic
        Console.WriteLine("Background job is running...");

        Thread.Sleep(TimeSpan.FromMinutes(2));
        
        // Your background job logic
        Console.WriteLine("Background job is exited...");
    }
    
    public void ProcessJobNoDelay()
    {
        // Your background job logic
        Console.WriteLine("Background job is running...");
        
        // Your background job logic
        Console.WriteLine("Background job is exited...");
    }
}