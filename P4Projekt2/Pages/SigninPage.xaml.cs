
using P4Projekt2.MVVM;
using P4Projekt2.API.Authorization;
using P4Projekt2.API.User;
using Refit;

namespace P4Projekt2.Pages
{
    public partial class SignInPage : ContentPage
    {
        private HttpClient _httpClient;
        public SignInPage()
        {
            InitializeComponent();
            //_httpClient
            BindingContext = new SignInPageViewModel();

        }
    }
}
