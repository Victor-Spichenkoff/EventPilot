using Microsoft.AspNetCore.Mvc;
using RoomReservation.Application.Services;

namespace RoomReservation.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController(TestService testService)
{
    private readonly TestService _testService = testService;
    
    [HttpGet]
    public string Get() => "Hello World!";
    
    [HttpGet("/test2")]
    public string Get2() => _testService.GetTestString();
}