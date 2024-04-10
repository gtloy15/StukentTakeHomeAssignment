namespace Backend.Interview.Api.Services;

// Typically I would handle logging through Azure App Insights or something similar, but for the sake of
// this example project I'll be using this class as a place holder
public class MakeShiftLogger : IMakeShiftLogger
{
    public void LogInfo(string message)
    {
        Console.WriteLine(message);
    }

    public void LogError(Exception ex)
    {
        Console.WriteLine("ERROR: " + ex.Message);
        Console.WriteLine(ex.StackTrace);
    }
}
