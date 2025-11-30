namespace RoomReservation.Extensions;

public static class UseSwaggerDocumentationExtension
{
    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}