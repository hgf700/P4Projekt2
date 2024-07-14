using P4Projekt2.MVVM;

namespace P4Projekt2.Pages
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage(SignInPageViewModel signInViewModel)
        {
            InitializeComponent();
            BindingContext = signInViewModel;
        }
    }
}
