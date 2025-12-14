using EventPilot.Application.Services;
using EventPilot.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace EventPilot.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController(TestService testService)
{
    private readonly TestService _testService = testService;
    
    [HttpGet]
    public string Get() => "Hello World!";
    
    [HttpGet("/test2")]
    public string Get2() => _testService.GetTestString();

    [HttpGet("/test3")]
    public string RetrunSomething([FromQuery] string v)
    {
        int gh = 0;
        if (v == "1")
            gh=(1 / gh);
            // throw new NotFoundException("Não achado!");
        return v;
    }
}