//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using P4Projekt2.Pages;

//namespace P4Projekt2.MVVM
//{
//    public class ChoseRegisterView
//    {
//        public SignInPageViewModel()
//        {
//            RegisterDoctorCommand = new Command(SignUpPage);
//            RegisterUserCommand = new Command(SignUpPage);
//        }
//    }
//}
//using Microsoft.Maui.Graphics.Text;
//using Microsoft.Maui;
//using Microsoft.UI.Xaml.Controls;
//using Microsoft.WindowsAppSDK.Runtime.Packages;
//using static System.Net.Mime.MediaTypeNames;

//using System.Security.Claims;

//<? xml version = "1.0" encoding = "utf-8" ?>
//< ContentPage
//    x:Class = "P4Projekt2.Pages.ChoseRegisterPage"
//    xmlns = "http://schemas.microsoft.com/dotnet/2021/maui"
//    xmlns: x = "http://schemas.microsoft.com/winfx/2009/xaml"
//    xmlns: vm = "clr-namespace:P4Projekt2.MVVM"
//    Title = "ChoseRegisterPage" >



//    < ScrollView >
//                    < Button
//                Padding = "16"
//                Background = "{DynamicResource Primary}"
//                Command = "{Binding RegisterDoctorCommand}"
//                CornerRadius = "4"
//                Text = "SIGN IN"
//                TextColor = "{DynamicResource White}" />

//                < Button
//                Padding = "16"
//                Background = "{DynamicResource Primary}"
//                Command = "{Binding RegisterUserCommand}"
//                CornerRadius = "4"
//                Text = "SIGN IN"
//                TextColor = "{DynamicResource White}" />
//    </ ScrollView >
//</ ContentPage >


//using P4Projekt2.MVVM;

//namespace P4Projekt2.Pages
//{
//    public partial class ChoseRegisterPage : ContentPage
//    {
//        public ChoseRegisterPage()
//        {
//            InitializeComponent();
//            BindingContext = new ChoseRegisterView();
//        }
//    }
//}