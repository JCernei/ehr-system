namespace Server.Composition;

public static class PresentationModule
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        return services;
    }
}
