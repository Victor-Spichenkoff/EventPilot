using EventPilot.Domain.Exceptions;

namespace EventPilot.Utils;

public static class ExceptionMapper
{
    public static (int status, string title) Map(Exception ex) =>
        ex switch
        {
            NotFoundException => (404, "Not Found"),
            BusinessException => (400, "Business Exception"),
            InternalServerException => (500, "Internal Server Error"),
            _ => (500, "Something went wrong")
        };
}