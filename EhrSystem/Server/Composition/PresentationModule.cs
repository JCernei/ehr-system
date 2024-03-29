using Application.Commands.LoginUser;
using Application.Commands.RegisterUser;
using Application.Queries.GetConsultations;
using Application.Queries.GetUserDetails;

namespace Server.Composition;

public static class PresentationModule
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(Program).Assembly);
            config.RegisterServicesFromAssembly(typeof(GetConsultationsQuery).Assembly);
        });

        return services;
    }
}
