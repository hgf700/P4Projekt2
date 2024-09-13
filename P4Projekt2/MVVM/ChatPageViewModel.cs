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
using Microsoft.AspNet.SignalR.Client.Http;


namespace P4Projekt2.MVVM
{
    public class ChatPageViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<Contact> Contacts { get; set; }
        public ObservableCollection<MessageData> Messages { get; set; }

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
        public ICommand LoadMessagesCommand { get; }


        public ChatPageViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient; // Use the passed-in httpClient

            Contacts = new ObservableCollection<Contact>();

            Messages = new ObservableCollection<MessageData>();


            LoadFriendsCommand = new Command(async () => await LoadFriends());
            AddFriendCommand = new Command(AddFriend);
            LogoutCommand = new Command(Logout);
            SendMessageCommand = new Command(SendMesage);
            _userEmail = Preferences.Get("UserEmail", string.Empty);
            LoadMessagesCommand = new Command(async () => await LoadMessages());

            LoadMessagesCommand.Execute(null);
            LoadFriendsCommand.Execute(null);
        }
        private async void SendMesage()
        {
            if (_selectedContact == null)
            {
                MessagingCenter.Send(this, "SendMesageError", "No contact selected.");
                return;
            }

            var messageRequest = new UserChatData()
            {
                Message = _newMessage,
                SenderEmail = _userEmail,
                ReceiverEmail = _selectedContact.Email,
                Timestamp = DateTime.UtcNow,
                IsSentByCurrentUser=true,
            };

            if (string.IsNullOrEmpty(messageRequest.Message))
            {
                MessagingCenter.Send(this, "SendMesageError", "Message box is empty");
                return;
            }

            if (string.IsNullOrEmpty(messageRequest.SenderEmail) || string.IsNullOrEmpty(messageRequest.ReceiverEmail))
            {
                MessagingCenter.Send(this, "SendMesageError", "Sender email or receiver email is null");
                return;
            }

            var url = "https://localhost:5014/authorization/user/message";

            try
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(messageRequest), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, httpContent);


                if (response.IsSuccessStatusCode)
                {
                    MessagingCenter.Send(this, "SendMesageSuccess", "Message sent successfully.");
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<dynamic>(responseContent);


                    NewMessage = string.Empty;
                }
                else
                {

                    var errorResponse = await response.Content.ReadAsStringAsync();
                    MessagingCenter.Send(this, "SendMesageError", $"Error during sending message: {response.ReasonPhrase} - {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                MessagingCenter.Send(this, "SendMesageError", $"Exception occurred: {ex.Message}");
            }
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



        private async Task LoadMessages()
        {
            if (_selectedContact == null || string.IsNullOrEmpty(_userEmail))
                return;

            var url = $"https://localhost:5014/authorization/user/getmessages/{_userEmail}/{_selectedContact.Email}";

            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var messages = JsonConvert.DeserializeObject<List<MessageData>>(responseContent);

                    if (messages != null && messages.Any())
                    {
                        // Update IsSentByCurrentUser property
                        foreach (var message in messages)
                        {
                            message.IsSentByCurrentUser = message.SenderEmail == _userEmail;
                        }

                        Messages.Clear();
                        foreach (var message in messages)
                        {
                            Messages.Add(message);
                        }
                        MessagingCenter.Send(this, "ChatSuccess", "Messages loaded successfully.");
                    }
                    else
                    {
                        MessagingCenter.Send(this, "ChatError", "No messages found.");
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


}
public class Contact
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Name => $"{Firstname} {Lastname}";
}

public class MessageData
{
    public string Message { get; set; }
    public string SenderEmail { get; set; }
    public string ReceiverEmail { get; set; }
    public DateTime Timestamp { get; set; }
    public bool IsSentByCurrentUser { get; set; } // Add this property
}

public class MessageTemplateSelector : DataTemplateSelector
{
    public DataTemplate SentTemplate { get; set; }
    public DataTemplate ReceivedTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var message = item as MessageData;
        return message.IsSentByCurrentUser ? SentTemplate : ReceivedTemplate;
    }
}



