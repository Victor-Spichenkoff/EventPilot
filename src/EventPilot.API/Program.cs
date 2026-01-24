using EventPilot.Application;
using EventPilot.Extensions;
using EventPilot.Infrastructure;
using EventPilot.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

// app.RunMigrations();

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
