using System.Windows.Input;
using P4Projekt2.Pages;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;
using P4Projekt2.API.Authorization;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Text;
using Refit;
using static System.Formats.Asn1.AsnWriter;

namespace P4Projekt2.MVVM
{
    public partial class SignUpPageViewModel : BaseViewModel
    {

        private bool _navigated = false;
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
            var tokenRequest = new RegisterAccount()
            {
                ResponseType = "register",
                Email = _Email,
                Password = _Password,
                Firstname = _FirstName,
                Lastname = _LastName,
                ClientId = "postman",
                Scope = "scope",
                State = "state",
                RedirectUri = "redirecturi",
                CodeChallenge = "codechallenge",
                CodeChallengeMethod = "codechallengemethod",
            };

            if (string.IsNullOrEmpty(tokenRequest.Firstname) || string.IsNullOrEmpty(tokenRequest.Email) || string.IsNullOrEmpty(tokenRequest.Password) || string.IsNullOrEmpty(tokenRequest.Lastname))
            {
                MessagingCenter.Send(this, "SignUpError", "Incorrect data");
                return;
            }

            var url = "https://localhost:5014/authorization/user/register";

            try
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(tokenRequest), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    MessagingCenter.Send(this, "SignUpSuccess", $"Data has been successfully sent for user: {tokenRequest?.Firstname} {tokenRequest?.Lastname} \n Redirecting to SignInPage ");

                    //Device.StartTimer(TimeSpan.FromSeconds(3), () =>
                    //{
                    //    //if (!_navigated)
                    //{
                    //    _navigated = true;
                    App.Current.MainPage = new SignInPage();
                    //}
                    //return false; // Zatrzymuje timer
                    //});
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
