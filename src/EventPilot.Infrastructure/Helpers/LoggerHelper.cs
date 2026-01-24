using Microsoft.Extensions.Logging;

namespace EventPilot.Infrastructure.Helpers;

public static class LogHelper
{
    private static readonly ILogger _logger =
        LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        }).CreateLogger("CustomLogger");

    public static void Info(string message)
    {
        _logger.LogInformation(message);
    }

    public static void Info(EventId eventId,
        string message)
    {
        _logger.LogInformation(eventId, message);
    }
}


enum LoggerEventId
{
    Debug = -1,
    StartUp = 1001
}
