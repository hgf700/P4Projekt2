using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using P4Projekt2.API.Authorization;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Input;
using P4Projekt2.Pages;
using Newtonsoft.Json;
using Microsoft.Maui.ApplicationModel.Communication;

namespace P4Projekt2.MVVM
{
    public partial class SignInPageViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
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

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public SignInPageViewModel(HttpClient httpClient = null)
        {
            LoginCommand = new Command(SignIn);
            RegisterCommand = new Command(SignUp);

            _httpClient = httpClient ?? new HttpClient(); 
        }

        private async void SignUp(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SignUpPage());
        }

        private async void SignIn()
        {
            var loginRequest = new LoginAccount()
            {
                ResponseType = "login",
                Email = _Email,
                PasswordHash = _Password,
                ClientId = "postman",
            };
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.PasswordHash))
            {
                MessagingCenter.Send(this, "SignUpError", "Incorrect data");
                return;
            }
            var url = "https://localhost:5014/authorization/user/login";

            try
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, httpContent);

                if (response.IsSuccessStatusCode)
                {

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<dynamic>(responseContent);
                    System.Diagnostics.Debug.WriteLine($"Response content: {responseContent}");


                    MessagingCenter.Send(this, "SignInSuccess", $"User has been successfully logged in: \n Redirecting to ChatPage ");

                    Preferences.Set("UserEmail", _Email);

                    App.Current.MainPage = new ChatPage();
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
