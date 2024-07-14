using System.Windows.Input;
using P4Projekt2.Pages;
using P4Projekt2.MVVM;

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

        private async void SignUp(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage());
        }

        private void Login(object obj)
        {
            App.Current.MainPage = new SignInPage();
        }

    }
}



//namespace P4Projekt2.MVVM
//{
//    public partial class SignUpPageViewModel : ObservableObject
//    {
//        private readonly IAuth _userIdentityApi;
//        private readonly IUserApi _usersInfoApi;

//        public SignUpPageViewModel(IAuth userIdentityApi, IUserApi usersInfoApi)
//        {
//            _userIdentityApi = userIdentityApi;
//            _usersInfoApi = usersInfoApi;
//        }

//        [ObservableProperty]
//        private string firstname;

//        [ObservableProperty]
//        private string lastname;

//        [ObservableProperty]
//        private string email;

//        [ObservableProperty]
//        private string password;

//        [RelayCommand]
//        private async Task SignUp()
//        {
//            var userIdentity = new IdentityUserInfo();
//            userIdentity.Firstname = firstname;
//            userIdentity.Lastname = lastname;
//            userIdentity.Email = email;
//            userIdentity.Password = password;
//            var resposne = await _userIdentityApi.CreateNewIdentity(userIdentity);
//            if (resposne.StatusCode == HttpStatusCode.BadRequest)
//            {
//                await Application.Current.MainPage.DisplayAlert("Sign Up", "Wrong forms!", "OK");
//            }

//            if (resposne.StatusCode == HttpStatusCode.OK)
//            {
//                var authTokenRequest = new AuthTokenRequest
//                {
//                    Granttype = "password",
//                    Firstname = firstname,
//                    Lastname = lastname,
//                    Password = password,
//                    ClientId = "postman",
//                    ClientSecret = "NotASecret",
//                };

//                var userInfo = new DtoUserInfo();
//                userInfo.Firstname = firstname;
//                userInfo.Lastname = lastname;
//                userInfo.Email = email;


//                var response = await _userIdentityApi.Execute(authTokenRequest);
//                var token = $"Bearer {response.Content.AccessToken}";

//                var res = await _usersInfoApi.CreateUser(userInfo, token);

//                if (res.StatusCode == HttpStatusCode.Created)
//                {
//                    await Application.Current.MainPage.DisplayAlert(
//                        "Sign Up",
//                        "Sign up successful!",
//                        "OK"
//                    );
//                    await Shell.Current.GoToAsync(nameof(MainPage));
//                }
//                else
//                {
//                    await Application.Current.MainPage.DisplayAlert(
//                        "Sign Up",
//                        "Something Went Wrong",
//                        "OK"
//                    );
//                }
//            }
//        }
//    }