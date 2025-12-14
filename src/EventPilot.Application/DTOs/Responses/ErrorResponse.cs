using System.Diagnostics;

namespace EventPilot.Application.DTOs.Responses;

public class ErrorResponse
{
    public int Status { get; set; } // HTTP Status Code
    public string Title { get; set; } // Short Message
    public string Detail { get; set; } // Error Message or Technical detail
    public string Instance { get; set; } // Endpoint or trace
    public string StackTrace { get; set; }
    public List<ErrorItem> Errors { get; set; } // Errors in validation
}

public class ErrorItem
{
    public string Field { get; set; }
    public string Message { get; set; }
}