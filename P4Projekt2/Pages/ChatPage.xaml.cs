﻿using P4Projekt2.MVVM;
using P4Projekt2.API.Authorization;
using Refit;

namespace P4Projekt2.Pages
{
    public partial class ChatPage : ContentPage
    {
        private HttpClient _httpClient;
        public ChatPage()
        {
            InitializeComponent();
            //_httpClient
            BindingContext = new ChatPageViewModel();


            MessagingCenter.Subscribe<ChatPageViewModel, string>(this, "ChatSuccess", async (sender, message) =>
            {
                await DisplayAlert("Success", message, "OK");
            });

            MessagingCenter.Subscribe<ChatPageViewModel, string>(this, "ChatError", async (sender, message) =>
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
