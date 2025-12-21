using EventPilot.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace EventPilot.Controllers.Tests;


[ApiController]
[Route("/test/error")]
public class ErrorHandlerController
{
    [HttpGet("unexpected")]
    public string GetUnexpected()
    {
        var n1 = 0;
        var n2 = 1 / n1;
        return "done";
    }
    
    [HttpGet("business")]
    public IActionResult Get() => throw new BusinessException("It's a business exception");
}