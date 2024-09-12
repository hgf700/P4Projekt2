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

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get => _selectedContact;
            set => SetProperty(ref _selectedContact, value);
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

        private async void BackChat(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ChatPage());
        }

        private async void AddFriend()
        {
            // Pobierz zalogowanego użytkownika (RequesterEmail)
            var requesterEmail = Preferences.Get("UserEmail", string.Empty); // Now getting the email correctly

            if (_selectedContact == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please select a contact to add as a friend.", "OK");
                return;
            }

            // Upewnij się, że wybrany kontakt ma Email
            if (string.IsNullOrEmpty(_selectedContact.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Selected contact has no email.", "OK");
                return;
            }

            var friendRequest = new AddFriendRequest()
            {
                RequesterIdLogin = requesterEmail,        // Email zalogowanego użytkownika
                FriendIdLogin = _selectedContact.Email,   // Email wybranego kontaktu
                RequestedAt = DateTime.UtcNow,
            };

            // Wyślij żądanie HTTP do API
            var url = "https://localhost:5014/authorization/user/addfriend";
            var jsonContent = new StringContent(JsonConvert.SerializeObject(friendRequest), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Friend request sent successfully.", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Failed to send friend request.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}
