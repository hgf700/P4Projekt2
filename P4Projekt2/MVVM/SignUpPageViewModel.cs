using System.Windows.Input;
using P4Projekt2.Pages;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;
using P4Projekt2.API.User;
using P4Projekt2.API.Authorization;
using static System.Net.WebRequestMethods;

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
            var userIdentity = new IdentityUserInfo
            {
                Email = Email_,
                Password = Password_,
                Firstname = FirstName_,
                Lastname = LastName_
            };

            if (string.IsNullOrEmpty(userIdentity.Firstname) || string.IsNullOrEmpty(userIdentity.Email) || string.IsNullOrEmpty(userIdentity.Password) || string.IsNullOrEmpty(userIdentity.Lastname))
            {
                MessagingCenter.Send(this, "SignUpError", "Incorrect data");
                return;
            }

            var url = "https://localhost:5013/api/user/register";

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, userIdentity);
                if (response.IsSuccessStatusCode)
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
                    //tylko chyba auth ma sens? bo po co mi zwykla zmienna a jakby tak do autoryzacji wykorzystac te okno z kodem na
                    //6 liter lub cyfr podczas rejestracji i ten kod byl by jako autoryzacja okreznie ale chyba ok?
                    var responseData = await response.Content.ReadFromJsonAsync<IdentityUserInfo>();
                    var responseauth= await _httpClient.PostAsJsonAsync(url, token);
                    var responseAuth = await responseauth.Content.ReadFromJsonAsync<AuthTokenRequest>();

                    MessagingCenter.Send(this, "SignUpSuccess", $"Data has been successfully sent for user: {responseData?.Firstname} {responseData?.Lastname}");
                    App.Current.MainPage = new SignInPage();
                }
                else
                {
                    MessagingCenter.Send(this, "SignUpError", $"Incorrect inserted data while login: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessagingCenter.Send(this, "SignUpError", $"Exception occurred: {ex.Message}");
            }
        }
    }
}
