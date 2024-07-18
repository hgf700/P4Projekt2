using Microsoft.Extensions.DependencyInjection;
using P4Projekt2.API.Authorization;
using P4Projekt2.API.User;
using P4Projekt2.MVVM;
using P4Projekt2.Pages;
using Refit;

namespace P4Projekt2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Konfiguracja Dependency Injection
            var services = new ServiceCollection();

            // Register Refit interfaces
            services.AddRefitClient<IAuth>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://your-api-base-url"));
            services.AddRefitClient<IUserApi>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://your-api-base-url"));

            var serviceProvider = services.BuildServiceProvider();

            MainPage = new SignUpPage
            {
                BindingContext = new SignUpPageViewModel(
                    serviceProvider.GetRequiredService<IAuth>(),
                    serviceProvider.GetRequiredService<IUserApi>()
                )
            };
        }
    }
}
