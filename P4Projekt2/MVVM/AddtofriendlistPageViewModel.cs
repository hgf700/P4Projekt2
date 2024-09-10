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
using Newtonsoft.Json;
using Microsoft.Maui.Storage;

namespace P4Projekt2.MVVM
{
    public partial class AddtofriendlistPageViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;

        private string _Firstname;
        public string Firstname
        {
            get => _Firstname;
            set => SetProperty(ref _Firstname, value);
        }

        private string _Lastname;
        public string Lastname
        {
            get => _Lastname;
            set => SetProperty(ref _Lastname, value);
        }

        private string _Email;
        public string Email
        {
            get => _Email;
            set => SetProperty(ref _Email, value);
        }

        public ICommand AddUserCommand { get; }
        public ICommand BackChatCommand { get; }

        public AddtofriendlistPageViewModel(HttpClient httpClient = null)
        {
            AddUserCommand = new Command(AddUser);
            BackChatCommand= new Command(BackChat);

            _httpClient = httpClient ?? new HttpClient();
        }

        private async void BackChat(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ChatPage());
        }

        private async void AddUser()
        {
            //a
        }
    }
}
