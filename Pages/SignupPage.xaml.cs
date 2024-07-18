using P4Projekt2.MVVM;
using P4Projekt2.API.Authorization;
using P4Projekt2.API.User;
using Refit;

namespace P4Projekt2.Pages
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            var userIdentity = RestService.For<IAuth>("http://10.0.2.2:7004/chathub");
            var usersInfo = RestService.For<IUserApi>("http://10.0.2.2:7004/chathub");

            // Przekaż je do ViewModel
            BindingContext = new SignUpPageViewModel(userIdentity, usersInfo);
        }
    }
}
