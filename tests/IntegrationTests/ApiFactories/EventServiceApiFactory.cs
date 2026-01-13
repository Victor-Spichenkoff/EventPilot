using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Application.Services;
using EventPilot.Domain.Entities;
using IntegrationTest.Helpers.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace IntegrationTest.ApiFactories;

public class EventServiceApiFactory
    : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Gets the real repository
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(IEventRepository));

            // Cleans the real repository
            if (descriptor != null)
                services.Remove(descriptor);

            // Mock do repositório
            var repoMock = new Mock<IEventRepository>();

            repoMock.Setup(r => r.UpdateAsync(It.IsAny<Event>()))
                .ReturnsAsync((Event e) => e);

            repoMock.Setup(r => r.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(() => EventHelper.GetStockEvent());
            
            services.AddScoped(_ => repoMock.Object);
        });
    }
}
