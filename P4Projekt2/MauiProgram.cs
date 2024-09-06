using Microsoft.Extensions.Logging;
using P4Projekt2.MVVM;

namespace P4Projekt2
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
                });
            builder.Services.AddSingleton<HttpClient>();


            builder.Services.AddTransient<SignInPageViewModel>();
            builder.Services.AddTransient<SignUpPageViewModel>();
            //builder.Services.AddTransient<ChatPageViewModel>();

            return builder.Build();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
