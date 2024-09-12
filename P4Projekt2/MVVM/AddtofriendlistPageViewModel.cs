using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using P4Projekt2.API.Authorization;
using P4Projekt2.API.User;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Input;
using P4Projekt2.Pages;
using Newtonsoft.Json;
using Microsoft.Maui.Storage;

namespace P4Projekt2.MVVM
{
    public partial class AddtofriendlistPageViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;

        private string _Email;
        public string Email
        {
            get => _Email;
            set => SetProperty(ref _Email, value);
        }

        public ICommand BackChatCommand { get; }
        public ICommand AddFriendCommand { get; }
        private string _userEmail;

        public AddtofriendlistPageViewModel(HttpClient httpClient)
        {
            BackChatCommand = new Command(BackChat);
            AddFriendCommand = new Command(AddFriend);
            _userEmail = Preferences.Get("UserEmail", string.Empty); // Corrected here

            _httpClient = httpClient;
        }

        private void BackChat(object obj)
        {
            App.Current.MainPage = new ChatPage();
        }

        private async void AddFriend()
        {
            var requesterEmail = Preferences.Get("UserEmail", string.Empty);

            var friendRequest = new AddFriendRequest
            {
                RequesterEmail = requesterEmail,
                FriendEmail = _Email,
                RequestedAt = DateTime.UtcNow
            };

            // Validate input
            if (string.IsNullOrEmpty(friendRequest.RequesterEmail))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Requester email is not set.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(friendRequest.FriendEmail))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Friend email is required.", "OK");
                return;
            }

            var url = "https://localhost:5014/authorization/user/addfriend";

            try
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(friendRequest), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    MessagingCenter.Send(this, "Addfriendsuccess", $"Addfriendsuccess ");

                    App.Current.MainPage = new ChatPage();
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    MessagingCenter.Send(this, "SignUpError", $"Error during sign-up: {response.ReasonPhrase} - {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

    }
}
