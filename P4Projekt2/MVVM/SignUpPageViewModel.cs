using System.Windows.Input;
using P4Projekt2.Pages;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;
using P4Projekt2.API.User;
using P4Projekt2.API.Authorization;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Text;
using Refit;

namespace P4Projekt2.MVVM
{
    public partial class SignUpPageViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        private string _Email;
        public string Email_
        {
            get => _Email;
            set => SetProperty(ref _Email, value);
        }

        private string _Password;
        public string Password_
        {
            get => _Password;
            set => SetProperty(ref _Password, value);
        }

        private string _FirstName;
        public string FirstName_
        {
            get => _FirstName;
            set => SetProperty(ref _FirstName, value);
        }

        private string _LastName;
        public string LastName_
        {
            get => _LastName;
            set => SetProperty(ref _LastName, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public SignUpPageViewModel(HttpClient httpClient)
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(SignUp);
            _httpClient = httpClient;
        }

        private void Login()
        {
            App.Current.MainPage = new SignInPage();
        }

        private async void SignUp()
        {
            var token = new AuthTokenRequest()
            {
                Granttype = "register",
                Email = _Email,
                Password = _Password,
                Firstname = _FirstName,
                Lastname = _LastName,
                ClientId = "postman",
            };

            // Validate input
            if (string.IsNullOrEmpty(token.Firstname) || string.IsNullOrEmpty(token.Email) || string.IsNullOrEmpty(token.Password) || string.IsNullOrEmpty(token.Lastname))
            {
                MessagingCenter.Send(this, "SignUpError", "Incorrect data");
                return;
            }

            var url = "https://localhost:5014/api/user/register";

            try
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(token), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    // Assuming the response contains a token or other success data.
                    MessagingCenter.Send(this, "SignUpSuccess", $"Data has been successfully sent for user: {token?.Firstname} {token?.Lastname}");
                    App.Current.MainPage = new SignInPage();
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    MessagingCenter.Send(this, "SignUpError", $"Error during sign-up: {response.ReasonPhrase} - {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                MessagingCenter.Send(this, "SignUpError", $"Exception occurred: {ex.Message}");
            }

        }
    }
}
