using System.Collections.ObjectModel;
using System.Windows.Input;
using P4Projekt2.Pages;

namespace P4Projekt2.MVVM
{
    public class ChatPageViewModel : BaseViewModel
    {
        // Przykładowa lista kontaktów
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

        public ChatPageViewModel()
        {
            Contacts = new ObservableCollection<Contact>
            {
                new Contact { Name = "Jane Smith" },
                new Contact { Name = "John Doe" } // Dodaj więcej kontaktów
            };

            // Sprawdź, czy Contacts jest poprawnie zainicjalizowane
            OnPropertyChanged(nameof(Contacts));

            AddFriendCommand = new Command(AddFriend);
            SendMessageCommand = new Command(SendMessage);
        }

        private void AddFriend()
        {
            // Logika dodawania znajomego
        }

        private void SendMessage()
        {
            // Logika wysyłania wiadomości
        }
    }
    public class Contact
    {
        public string Name { get; set; }  // Właściwość Name powinna być publiczna
    }
}
