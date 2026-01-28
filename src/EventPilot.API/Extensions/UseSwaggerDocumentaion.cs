namespace EventPilot.Extensions;

public static class UseSwaggerDocumentationExtension
{
    public static IApplicationBuilder UseMySwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventPilot v1");
            c.EnablePersistAuthorization();
            c.RoutePrefix = "swagger";
        });

        return app;
    }
}
