using P4Projekt2.MVVM;
using Microsoft.Maui.Controls;

namespace P4Projekt2.Pages
{
    public partial class SignUpPage : ContentPage
    {
        private HttpClient _httpClient;
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = new SignUpPageViewModel(_httpClient);

            MessagingCenter.Subscribe<SignUpPageViewModel, string>(this, "SignUpSuccess", async (sender, message) =>
            {
                await DisplayAlert("Success", message, "OK");
            });

            MessagingCenter.Subscribe<SignUpPageViewModel, string>(this, "SignUpError", async (sender, message) =>
            {
                await DisplayAlert("Error", message, "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<SignUpPageViewModel, string>(this, "SignUpSuccess");
            MessagingCenter.Unsubscribe<SignUpPageViewModel, string>(this, "SignUpError");
        }
    }
}
