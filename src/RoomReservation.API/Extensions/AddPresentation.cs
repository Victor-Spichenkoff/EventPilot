namespace RoomReservation.Extensions;

/*
 * The father's name don't matter
 */
public static class AddPresentationExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddEndpointsApiExplorer(); 
        services.AddSwaggerGen();

        return services;
    }
}