using System.Collections.ObjectModel;
using System.Windows.Input;
using P4Projekt2.Pages;
using P4Projekt2.API.User;
using Microsoft.Maui.Storage;
using P4Projekt2.MVVM;
using Newtonsoft.Json;
using System.Text;
using System;
using System.Net.Http;


namespace P4Projekt2.MVVM
{
    public class ChatPageViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<Contact> Contacts { get; set; }

        private string _userEmail;

        private string _newMessage;
        public string NewMessage
        {
            get => _newMessage;
            set
            {
                _newMessage = value;
                OnPropertyChanged(nameof(NewMessage));
            }
        }

        // Właściwość do wybrania kontaktu
        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
                // Możesz dodać logikę aktualizującą rozmowę po zmianie kontaktu
            }
        }
        private async void Logout()
        {
            Preferences.Set("UserEmail", null);

            await Application.Current.MainPage.Navigation.PushModalAsync(new SignInPage());
        }
        async private void AddFriend()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new AddtofriendlistPage(_httpClient));
        }

        // Komendy
        public ICommand AddFriendCommand { get; }
        public ICommand SendMessageCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand LoadFriendsCommand { get; }


        public ChatPageViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient; // Use the passed-in httpClient

            Contacts = new ObservableCollection<Contact>();
            LoadFriendsCommand = new Command(async () => await LoadFriends());
            AddFriendCommand = new Command(AddFriend);
            LogoutCommand = new Command(Logout);
            _userEmail = Preferences.Get("UserEmail", string.Empty);


            LoadFriendsCommand.Execute(null);
        }


        private async Task LoadFriends()
        {
            if (string.IsNullOrEmpty(_userEmail))
                return;

            var urlload = $"https://localhost:5014/authorization/user/friends/{_userEmail}";

            try
            {
                var response = await _httpClient.GetAsync(urlload);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the response into List<Contact>
                    var friends = JsonConvert.DeserializeObject<List<Contact>>(responseContent);

                    if (friends != null && friends.Any())
                    {
                        Contacts.Clear();
                        foreach (var friend in friends)
                        {
                            Contacts.Add(friend);
                        }
                        MessagingCenter.Send(this, "ChatSuccess", "Friends loaded successfully.");
                    }
                    else
                    {
                        MessagingCenter.Send(this, "ChatError", "No friends found.");
                    }
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    MessagingCenter.Send(this, "ChatError", $"Error: {response.ReasonPhrase} - {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                MessagingCenter.Send(this, "ChatError", $"Exception: {ex.Message}");
            }
        }



    }
    public class Contact
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Name => $"{Firstname} {Lastname}";
    }

}