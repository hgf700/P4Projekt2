using System.Windows.Input;
using P4Projekt2.Pages;
using P4Projekt2.MVVM;
using P4Projekt2.API.User;
using P4Projekt2.API.Authorization;
using System.Net;

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

        public readonly IAuth _userIdentityApi;
        public readonly IUserApi _usersInfoApi;
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public SignUpPageViewModel(IAuth userIdentityApi, IUserApi usersInfoApi)
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(SignUp);
            _userIdentityApi = userIdentityApi;
            _usersInfoApi = usersInfoApi;
        }

        private async void SignUp(object obj)
        {
            var userIdentity = new IdentityUserInfo();
            userIdentity.Email = _Email;
            userIdentity.Password = _Password;
            userIdentity.Firstname = _FirstName;
            userIdentity.Lastname = _LastName;
            var resposne = await _userIdentityApi.CreateNewIdentity(userIdentity);
            if (resposne.StatusCode == HttpStatusCode.BadRequest)
            {
                await Application.Current.MainPage.DisplayAlert("Sign Up", "Wrong forms!", "OK");
            }

            if (resposne.StatusCode == HttpStatusCode.OK)
            {
                var authTokenRequest = new AuthTokenRequest
                {
                    Granttype = "password",
                    Firstname = _FirstName,
                    Lastname = _LastName,
                    Email = _Email,
                    Password = _Password,
                    ClientId = "postman",
                    ClientSecret = "secret",
                };
                var userInfo = new DtoUserInfo();
                userInfo.Email = _Email;
                userInfo.Firstname = _FirstName;
                userInfo.Lastname = _LastName;
                var response = await _userIdentityApi.Execute(authTokenRequest);
                var token = $"Bearer {response.Content.AccessToken}";

                var res = await _usersInfoApi.CreateUser(userInfo, token);

                if (res.StatusCode == HttpStatusCode.Created)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Sign Up",
                        "Sign up successful!",
                        "OK"
                    );
                    //chat page
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ChatPage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Sign Up",
                        "Something Went Wrong",
                        "OK"
                    );
                }
            }

        }
        private void Login(object obj)
        {
            App.Current.MainPage = new SignInPage();
        }
    }
}
