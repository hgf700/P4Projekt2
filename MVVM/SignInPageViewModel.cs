using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly UserStore _userStore;
        public SignInPageViewModel()
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(SignUp);
        }
        private async void SignUp(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SignUpPage());
        }

        private async void Login()
        {
           
        }
    }
}
