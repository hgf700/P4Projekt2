
using P4Projekt2.MVVM;
using P4Projekt2.API.Authorization;
using P4Projekt2.API.User;
using Refit;

namespace P4Projekt2.Pages
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
            //var userIdentity = RestService.For<IAuth>("http://10.0.2.2:7004/chathub");
            //var usersInfo = RestService.For<IUserApi>("http://10.0.2.2:7004/chathub");
            //BindingContext = new SignInPageViewModel(userIdentity, usersInfo);
            BindingContext = new SignInPageViewModel();
        }
    }
}
