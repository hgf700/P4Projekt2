﻿//using Microsoft.AspNetCore.SignalR.Client;
//using P4Projekt2.MVVM;
//using System.Collections.ObjectModel;
//using System.Threading.Tasks;


using P4Projekt2.MVVM;
using P4Projekt2.API.Authorization;
using P4Projekt2.API.User;
using Refit;

namespace P4Projekt2.Pages
{
    public partial class ChatPage : ContentPage
    {
        //private HttpClient _httpClient;
        public ChatPage()
        {
            InitializeComponent();
            //_httpClient
            BindingContext = new ChatPageViewModel();

            //MessagingCenter.Subscribe<SignInPageViewModel, string>(this, "SignInSuccess", async (sender, message) =>
            //{
            //    await DisplayAlert("Success", message, "OK");
            //});

            //MessagingCenter.Subscribe<SignInPageViewModel, string>(this, "SignInError", async (sender, message) =>
            //{
            //    await DisplayAlert("Error", message, "OK");
            //});
        }

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    MessagingCenter.Unsubscribe<SignInPageViewModel, string>(this, "SignInSuccess");
        //    MessagingCenter.Unsubscribe<SignInPageViewModel, string>(this, "SignInError");
        //}
    }
}




//namespace P4Projekt2.Pages
//{
//    public partial class ChatPage : ContentPage
//    {
//        private HubConnection _connection;
//        private ObservableCollection<string> _messages = new ObservableCollection<string>();

//        public ChatPage()
//        {
//            InitializeComponent();
//            MessagesListView.ItemsSource = _messages;
//            _connection = new HubConnectionBuilder()
//                //.WithUrl("http://10.0.2.2:7004/chathub")
//                .Build();
//            _connection.On<string, string, string>(
//                "ReceiveMessage",
//                (user, message, conversationId) =>
//                {
//                    _messages.Add($"{user}: {message}");
//                }
//            );

//            Task.Run(async () => await ConnectToHub());
//        }

//        private async Task ConnectToHub()
//        {
//            try
//            {
//                await _connection.StartAsync();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error connecting to SignalR: {ex.Message}");
//            }
//        }

//        private async void OnSendClicked(object sender, EventArgs e)
//        {
//            var message = MessageEntry.Text;
//            try
//            {
//                await _connection.SendAsync(
//                    "SendMessage",
//                    "665886e203689af6fef699b1",
//                    "bob",
//                    message
//                );
//                MessageEntry.Text = string.Empty;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error sending message: {ex.Message}");
//            }
//        }
//    }
//}

