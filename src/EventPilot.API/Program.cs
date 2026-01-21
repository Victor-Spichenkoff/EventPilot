using EventPilot.Application;
using EventPilot.Extensions;
using EventPilot.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

app.UseMiddlewares();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwaggerDocumentation();
// }


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



public abstract partial class Program { }
