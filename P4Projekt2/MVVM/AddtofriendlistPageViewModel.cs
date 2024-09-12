using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using P4Projekt2.API.User;
using P4Projekt2.Pages;

namespace P4Projekt2.MVVM
{
    public partial class AddtofriendlistPageViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        private string _userEmail;

        private string _Email;
        public string Email
        {
            get => _Email;
            set => SetProperty(ref _Email, value);
        }

        public ICommand BackChatCommand { get; }
        public ICommand AddFriendCommand { get; }

        public AddtofriendlistPageViewModel(HttpClient httpClient)
        {
            BackChatCommand = new Command(SignUp);
            AddFriendCommand = new Command(AddFriend);
            _userEmail = Preferences.Get("UserEmail", string.Empty);

            _httpClient = httpClient;
        }

        private async void SignUp()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ChatPage());
        }

        private async void AddFriend()
        {
            var friendRequest = new AddFriendRequest
            {
                RequesterEmail = _userEmail,
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

                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    // Check if the response content is valid JSON
                    if (!string.IsNullOrWhiteSpace(responseContent))
                    {
                        // Optionally parse the response if needed
                        var responseData = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        MessagingCenter.Send(this, "Addfriendsuccess", $"Friend request sent successfully.");
                    }
                    else
                    {
                        MessagingCenter.Send(this, "SignUpError", "Empty response from server.");
                    }

                    App.Current.MainPage = new ChatPage();
                }
                else
                {
                    MessagingCenter.Send(this, "SignUpError", $"Error during friend request: {response.ReasonPhrase} - {responseContent}");
                }
            }
            catch (JsonException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error parsing response: {ex.Message}", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}
