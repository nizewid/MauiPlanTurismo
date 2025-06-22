using Microsoft.Extensions.Logging;

namespace MauiPlanTurismo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureEssentials(essentials =>
                {
                    essentials.UseVersionTracking();
                    essentials.AddAppAction("nuevo_viaje", "Nuevo viaje", icon: "coche.png");
                    essentials.AddAppAction("info_planes_turismo", "Info Planes Turismo", icon: "info.png");
                    essentials.AddAppAction("destino_granada", "Destino favorito", icon: "estrella_top.png");
                    essentials.AddAppAction("datos_usuario", "Datos usuario", icon: "usuario_fill.png");
                    essentials.OnAppAction(App.HandleAppActions);
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
