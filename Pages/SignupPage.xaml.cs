using P4Projekt2.MVVM;

namespace P4Projekt2.Pages
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = new SignUpPageViewModel();
        }
    }
}
//using P4Projekt2.MVVM;

//namespace P4Projekt2.Pages
//{
//    public partial class SignUpPage : ContentPage
//    {
//        public SignUpPage(SignUpPageViewModel signUpviewModel)
//        {
//            InitializeComponent();
//            BindingContext = signUpviewModel;
//        }
//    }
//}
