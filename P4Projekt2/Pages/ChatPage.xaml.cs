using P4Projekt2.MVVM;
using P4Projekt2.API.Authorization;
using Refit;

namespace P4Projekt2.Pages
{
    public partial class ChatPage : ContentPage
    {
        private HttpClient _httpClient;
        private ChatPageViewModel _viewModel;

        public ChatPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _viewModel = new ChatPageViewModel(_httpClient);
            BindingContext = _viewModel;

            // Subscribe to success messages
            MessagingCenter.Subscribe<ChatPageViewModel, string>(this, "ChatSuccess", async (sender, message) =>
            {
                await DisplayAlert("Success", message, "OK");
            });

            // Subscribe to error messages
            MessagingCenter.Subscribe<ChatPageViewModel, string>(this, "ChatError", async (sender, message) =>
            {
                await DisplayAlert("Error", message, "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Unsubscribe to avoid memory leaks
            MessagingCenter.Unsubscribe<ChatPageViewModel, string>(this, "ChatSuccess");
            MessagingCenter.Unsubscribe<ChatPageViewModel, string>(this, "ChatError");
        }
    }

}
