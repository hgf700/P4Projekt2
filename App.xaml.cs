using P4Projekt2.Pages;

namespace P4Projekt2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SignInPage();
        }
    }
}
