using System.Net;

namespace IntegrationTest.Controllers.Tests;


public class ErrorHandler 
    : IClassFixture<ApiFactory>
{
    private readonly HttpClient _client;

    public ErrorHandler(ApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Return_400_Business_Exception()
    {
        // Act
        var response = await _client.GetAsync("/test/error/business");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();

        Assert.Contains("business", content.ToLower());
        Assert.Contains("400", content);
    }

    [Fact]
    public async Task Should_Return_500_Server_Exception()
    {
        var response = await _client.GetAsync("/test/error/unexpected");
        var content = await response.Content.ReadAsStringAsync();
        
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

        Assert.Contains("unexpected", content);
        Assert.Contains("500", content);
        Assert.DoesNotContain("\"stackTrace\": null", content);
    }
}