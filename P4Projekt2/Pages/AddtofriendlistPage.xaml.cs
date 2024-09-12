using P4Projekt2.MVVM;
using System.Net.Http;

namespace P4Projekt2.Pages
{
    public partial class AddtofriendlistPage : ContentPage
    {
        private readonly HttpClient _httpClient;

        public AddtofriendlistPage(HttpClient httpClient)
        {
            InitializeComponent();
            _httpClient = httpClient;
            BindingContext = new AddtofriendlistPageViewModel(_httpClient);

            MessagingCenter.Subscribe<AddtofriendlistPageViewModel, string>(this, "Addfriendsuccess", async (sender, message) =>
            {
                await DisplayAlert("Success", message, "OK");
            });

            MessagingCenter.Subscribe<AddtofriendlistPageViewModel, string>(this, "SignUpError", async (sender, message) =>
            {
                await DisplayAlert("Error", message, "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AddtofriendlistPageViewModel, string>(this, "Addfriendsuccess");
            MessagingCenter.Unsubscribe<AddtofriendlistPageViewModel, string>(this, "SignUpError");
        }
    }

}
