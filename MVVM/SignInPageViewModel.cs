using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Refit;
using P4Projekt2.API.Authorization;
using P4Projekt2.API.User;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Input;
using P4Projekt2.Pages;

namespace P4Projekt2.MVVM
{
    public partial class SignInPageViewModel : BaseViewModel
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

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public SignInPageViewModel()
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(SignUp);
        }
        private async void SignUp(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SignUpPage());
        }

        private void Login(object obj)
        {
            App.Current.MainPage = new AppShell();
        }
    }
}




////private readonly IAuth _authApi;
////private readonly IUserApi _userApi;
//private readonly UserStore _userStore;

////public SignInPageViewModel(IAuth userIdentityApi, IUserApi usersInfoApi)
////{
////    _authApi = userIdentityApi;
////    _userApi = usersInfoApi;

////    _userStore = App.Current.Handler.MauiContext.Services.GetService<UserStore>();
////}

//[ObservableProperty]
//private string _errorMessage;

//[ObservableProperty]
//private string _email;

//[ObservableProperty]
//private string _password;

//[RelayCommand]
//public async Task SignIn()
//{
//    var authTokenRequest = new AuthTokenRequest
//    {
//        Granttype = "password",
//        Firstname = $"firstname",
//        Lastname = $"lastname",
//        Password = $"Pass123$",
//        ClientId = "postman",
//        ClientSecret = "NotASecret",
//    };

//    //try
//    //{
//    //    //var response = await _authApi.Execute(authTokenRequest);

//    //    if (response.IsSuccessStatusCode)
//    //    {
//    //        var accessToken = response.Content.AccessToken;
//    //        if (accessToken == null)
//    //        {
//    //            ErrorMessage = "Invalid Login/Password";
//    //            return;
//    //        }

//    //        _userStore.Email = authTokenRequest.Email;
//    //        _userStore.AccessToken = response.Content.AccessToken;

//    //        Email = string.Empty;
//    //        Password = string.Empty;
//    //        ErrorMessage = string.Empty;

//    //        // Log the token being used for authorization
//    //        Debug.WriteLine($"Using Access Token: Bearer {accessToken}");

//    //        var fetchedUser = await _userApi.GetUserInfo(
//    //            _userStore.Email,
//    //            $"Bearer {_userStore.AccessToken}"
//    //        );
//    //        if (fetchedUser != null)
//    //        {
//    //            await Shell.Current.GoToAsync("//App");
//    //        }
//    //        ErrorMessage = "Couldn't retrieve user info";

//    //        Debug.WriteLine($"Fetched User Info: {fetchedUser}");
//    //    }
//    //    else
//    //    {
//    //        Debug.WriteLine($"Request failed with status code: {response.StatusCode}");
//    //        Debug.WriteLine($"Reason: {response.ReasonPhrase}");
//    //        ErrorMessage = "Login failed. Please try again.";
//    //    }
//    //}
//    //catch (ApiException apiEx)
//    //{
//    //    Debug.WriteLine($"API Error: {apiEx.StatusCode}");
//    //    Debug.WriteLine($"Content: {apiEx.Content}");
//    //    ErrorMessage = "An error occurred during login. Please try again.";
//    //}
//    //catch (Exception ex)
//    //{
//    //    Debug.WriteLine($"Unexpected Error: {ex.Message}");
//    //    ErrorMessage = "An unexpected error occurred. Please try again.";
//    //}
//}