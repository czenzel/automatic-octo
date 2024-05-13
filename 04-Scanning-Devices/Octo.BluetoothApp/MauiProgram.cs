using Microsoft.Extensions.Logging;
using Shiny;
using Shiny.Infrastructure;

namespace Octo.BluetoothApp
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
                .ConfigureShiny()
                .ConfigurePages();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder ConfigureShiny(this MauiAppBuilder builder)
        {
            builder.Services.AddShinyCoreServices();
            builder.Services.AddBluetoothLE();
            return builder;
        }

        private static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
        {
            return builder;
        }
    }
}
