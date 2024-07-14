//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using P4Projekt2.API.Authorization;
//using P4Projekt2.API.User;
//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using System.Net;

//namespace P4Projekt2.MVVM
//{
//    public partial class SignUpPageViewModel : ObservableObject
//    {
//        //private readonly IAuth _userIdentityApi;
//        //private readonly IUserApi _usersInfoApi;

//        //public SignUpPageViewModel(IAuth userIdentityApi, IUserApi usersInfoApi)
//        //{
//        //    _userIdentityApi = userIdentityApi;
//        //    _usersInfoApi = usersInfoApi;
//        //}

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
//            //var resposne = await _userIdentityApi.CreateNewIdentity(userIdentity);
//            //if (resposne.StatusCode == HttpStatusCode.BadRequest)
//            //{
//            //    await Application.Current.MainPage.DisplayAlert("Sign Up", "Wrong forms!", "OK");
//            //}

//            //if (resposne.StatusCode == HttpStatusCode.OK)
//            //{
//            var authTokenRequest = new AuthTokenRequest
//            {
//                Granttype = "password",
//                Firstname = firstname,
//                Lastname = lastname,
//                Password = password,
//                ClientId = "postman",
//                ClientSecret = "NotASecret",
//            };

//            var userInfo = new DtoUserInfo();
//            userInfo.Firstname = firstname;
//            userInfo.Lastname = lastname;
//            userInfo.Email = email;


//            //var response = await _userIdentityApi.Execute(authTokenRequest);
//            //var token = $"Bearer {response.Content.AccessToken}";

//            //var res = await _usersInfoApi.CreateUser(userInfo, token);

//            //if (res.StatusCode == HttpStatusCode.Created)
//            //{
//            //    await Application.Current.MainPage.DisplayAlert(
//            //        "Sign Up",
//            //        "Sign up successful!",
//            //        "OK"
//            //    );
//            //    await Shell.Current.GoToAsync(nameof(MainPage));
//            //}
//            //else
//            //{
//            //    await Application.Current.MainPage.DisplayAlert(
//            //        "Sign Up",
//            //        "Something Went Wrong",
//            //        "OK"
//            //    );
//            //}
//            //}
//        }
//    }
//}