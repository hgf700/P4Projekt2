using Microsoft.Extensions.DependencyInjection;
using P4Projekt2.API.Authorization;
using P4Projekt2.MVVM;
using P4Projekt2.Pages;
using Refit;

namespace P4Projekt2
{
    public partial class App : Application
    {
        private HttpClient _httpClient;
        public App()
        {

            InitializeComponent();

            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            MainPage = new SignUpPage
            {
                BindingContext = serviceProvider.GetRequiredService<SignUpPageViewModel>()
            };
        }
        private void ConfigureServices(IServiceCollection services)
        {
            // Rejestracja HttpClient
            services.AddHttpClient<SignUpPageViewModel>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5014"); // Adres Twojego serwera
            });

            // Rejestracja ViewModel jako usługi
            services.AddTransient<SignUpPageViewModel>();
        }
        protected override void OnSleep()
        {
            base.OnSleep();
            //Stop local API server
            //_localApiServer?.Stop();
        }
    }
}
