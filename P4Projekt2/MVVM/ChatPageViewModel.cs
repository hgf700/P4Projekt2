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

        // Właściwość do wprowadzenia nowej wiadomości
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

        // Komendy
        public ICommand AddFriendCommand { get; }
        public ICommand SendMessageCommand { get; }
        public ICommand LogoutCommand { get; }

        private string _userEmail;
        public ChatPageViewModel(HttpClient httpClient)
        {

            Contacts = new ObservableCollection<Contact>
            {
                new Contact { Firstname = "Jane", Lastname="Smith" , Email = "jane.smith@example.com" },
                new Contact { Firstname = "John", Lastname="Doe", Email = "john.doe@example.com" },
            };

            // Sprawdź, czy Contacts jest poprawnie zainicjalizowane
            OnPropertyChanged(nameof(Contacts));

            AddFriendCommand = new Command(AddFriend);
            SendMessageCommand = new Command(SendMessage);
            LogoutCommand = new Command(Logout);


            _userEmail = Preferences.Get("UserEmail", string.Empty);
            _httpClient = httpClient;
        }

        async private void Logout()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SignInPage());
        }

        async private void AddFriend()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new AddtofriendlistPage());
        }

        private async void SendMessage()
        {

            var message = new UserChatData
            {
                Message = NewMessage,
                SenderEmail = _userEmail,
                Timestamp = DateTime.UtcNow,
                ReceiverEmail = "avc"
                //SelectedContact.Email
            };


            if (string.IsNullOrEmpty(message.Message))
            {
                MessagingCenter.Send(this, "message error", "insert data to message box");
                return;
            }
            if (string.IsNullOrEmpty(message.ReceiverEmail))
            {
                MessagingCenter.Send(this, "message error", "choose user to send data");
                return;
            }

            var url = "https://localhost:5014/authorization/user/message";

            try
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    MessagingCenter.Send(this, "send", "Data sended");

                }


            }
            catch (Exception ex)
            {
                MessagingCenter.Send(this, "sendmessageerror", $"{ex.Message}");
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