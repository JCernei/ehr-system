using MudBlazor;
using MudBlazor.Services;

namespace Client;

public static class DependencyInjection
{
    public static IServiceCollection AddMudBlazorServices(this IServiceCollection services)
    {
        services.AddMudServices(mudServicesConfiguration =>
        {
            mudServicesConfiguration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
            mudServicesConfiguration.SnackbarConfiguration.PreventDuplicates = false;
            mudServicesConfiguration.SnackbarConfiguration.NewestOnTop = true;
            mudServicesConfiguration.SnackbarConfiguration.ShowCloseIcon = true;
            mudServicesConfiguration.SnackbarConfiguration.VisibleStateDuration = 3000;
            mudServicesConfiguration.SnackbarConfiguration.HideTransitionDuration = 500;
            mudServicesConfiguration.SnackbarConfiguration.ShowTransitionDuration = 500;
            mudServicesConfiguration.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });

        return services;
    }
}
