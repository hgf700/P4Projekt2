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
        private HttpClient _httpClient;
        public App()
        {

            InitializeComponent();

            _httpClient = new HttpClient();

            MainPage = new SignUpPage
            {
                BindingContext = new SignUpPageViewModel(_httpClient)
            };

            //_localApiServer = new LocalApiServer();
            //_localApiServer.Start();
        }
        protected override void OnSleep()
        {
            base.OnSleep();
            //Stop local API server
            //_localApiServer?.Stop();
        }
    }
}
