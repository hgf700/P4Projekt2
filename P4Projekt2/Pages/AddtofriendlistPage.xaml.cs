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


            MessagingCenter.Subscribe<AddtofriendlistPageViewModel, string>(this, "AddfirendSuccess", async (sender, message) =>
            {
                await DisplayAlert("Success", message, "OK");
            });

            MessagingCenter.Subscribe<AddtofriendlistPageViewModel, string>(this, "AddfirendError", async (sender, message) =>
            {
                await DisplayAlert("Error", message, "OK");
            });

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AddtofriendlistPageViewModel, string>(this, "AddfirendSuccess");
            MessagingCenter.Unsubscribe<AddtofriendlistPageViewModel, string>(this, "AddfirendError");
        }
    }
}
