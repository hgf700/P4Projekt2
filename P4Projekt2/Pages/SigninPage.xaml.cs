
using P4Projekt2.MVVM;
using P4Projekt2.API.Authorization;
using Refit;

namespace P4Projekt2.Pages
{
    public partial class SignInPage : ContentPage
    {
        private HttpClient _httpClient;
        public SignInPage()
        {
            InitializeComponent();
            BindingContext = new SignInPageViewModel(_httpClient);

            MessagingCenter.Subscribe<SignInPageViewModel, string>(this, "SignInSuccess", async (sender, message) =>
            {
                await DisplayAlert("Success", message, "OK");
            });

            MessagingCenter.Subscribe<SignInPageViewModel, string>(this, "SignInError", async (sender, message) =>
            {
                await DisplayAlert("Error", message, "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<SignInPageViewModel, string>(this, "SignInSuccess");
            MessagingCenter.Unsubscribe<SignInPageViewModel, string>(this, "SignInError");
        }
    }
}
