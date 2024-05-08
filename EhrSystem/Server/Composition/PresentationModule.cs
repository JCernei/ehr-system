using Application.Queries.GetConsultations;
using Application.Queries.GetLabResults;

namespace Server.Composition;

public static class PresentationModule
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(Program).Assembly);
            config.RegisterServicesFromAssembly(typeof(GetConsultationsQuery).Assembly);
            config.RegisterServicesFromAssembly(typeof(GetLabResultsQuery).Assembly);
        });

        return services;
    }
}
