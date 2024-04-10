namespace Backend.Interview.Api.Services;

public interface IMakeShiftLogger
{
    void LogInfo(string message);
    void LogError(Exception ex);
}
