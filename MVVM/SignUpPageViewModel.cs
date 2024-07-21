using System.Windows.Input;
using P4Projekt2.Pages;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;
using P4Projekt2.API.User;

namespace P4Projekt2.MVVM
{
    public partial class SignUpPageViewModel : BaseViewModel
    {
        private string _Email;
        public string Email
        {
            get => _Email;
            set => SetProperty(ref _Email, value);
        }

        private string _Password;
        public string Password
        {
            get => _Password;
            set => SetProperty(ref _Password, value);
        }

        private string _FirstName;
        public string FirstName
        {
            get => _FirstName;
            set => SetProperty(ref _FirstName, value);
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set => SetProperty(ref _LastName, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public SignUpPageViewModel()
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(SignUp);
        }

        private void Login()
        {
            App.Current.MainPage = new SignInPage();
        }

        private async void SignUp()
        {
            var userIdentity = new IdentityUserInfo
            {
                Email = _Email,
                Password = _Password,
                Firstname = _FirstName,
                Lastname = _LastName
            };

            if (string.IsNullOrEmpty(userIdentity.Firstname) || string.IsNullOrEmpty(userIdentity.Email) || string.IsNullOrEmpty(userIdentity.Password) || string.IsNullOrEmpty(userIdentity.Lastname))
            {
                MessagingCenter.Send(this, "SignUpError", "Incorrect data");
                return;
            }

            var url = "http://localhost:5000";
            using var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.PostAsJsonAsync(url, userIdentity);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadFromJsonAsync<IdentityUserInfo>();
                    MessagingCenter.Send(this, "SignUpSuccess", $"Data has been successfully sent for user: {responseData?.Firstname} {responseData?.Lastname}");

                    App.Current.MainPage = new SignInPage();
                }
                else
                {
                    MessagingCenter.Send(this, "SignUpError", $"Incorrect inserted data: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessagingCenter.Send(this, "SignUpError", $"Exception occurred: {ex.Message}");
            }
        }
    }
}
