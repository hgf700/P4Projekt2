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

            // Subscribe to success messages
            MessagingCenter.Subscribe<ChatPageViewModel, string>(this, "SendMesageSuccess", async (sender, message) =>
            {
                await DisplayAlert("Success", message, "OK");
            });

            // Subscribe to error messages
            MessagingCenter.Subscribe<ChatPageViewModel, string>(this, "SendMesageError", async (sender, message) =>
            {
                await DisplayAlert("Error", message, "OK");
            });

            MessagingCenter.Subscribe<ChatPageViewModel, string>(this, "LoadMessagesSuccess", async (sender, message) =>
            {
                await DisplayAlert("Success", message, "OK");
            });

            // Subscribe to error messages
            MessagingCenter.Subscribe<ChatPageViewModel, string>(this, "LoadMessagesError", async (sender, message) =>
            {
                await DisplayAlert("Error", message, "OK");
            });


            // Subscribe to error messages
            MessagingCenter.Subscribe<ChatPageViewModel, string>(this, "LoadMessagesexceptionError", async (sender, message) =>
            {
                await DisplayAlert("Error", message, "OK");
            });

            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<ChatPageViewModel, string>(this, "ChatSuccess");
            MessagingCenter.Unsubscribe<ChatPageViewModel, string>(this, "ChatError");
        }
    }

}
