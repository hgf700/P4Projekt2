using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using P4Projekt2.Pages;

namespace P4Projekt2.MVVM
{
    public partial class MainPageViewModel : ObservableObject
    {
        [RelayCommand]
        async Task NavigateToSignIn()
        {
            await Shell.Current.GoToAsync(nameof(SignInPage));
        }

        //[RelayCommand]
        //async Task NavigateToSignUp()
        //{
        //    await Shell.Current.GoToAsync(nameof(SignUpPage));
        //}
    }
}
