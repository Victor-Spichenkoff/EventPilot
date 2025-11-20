using Microsoft.AspNetCore.Mvc;

namespace RoomReservation.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController
{
    [HttpGet]
    public string Get() => "Hello World!";
}