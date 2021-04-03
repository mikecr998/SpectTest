using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using SpectTest.Views;
using SpectTest.Services;
using SpectTest.DB;

namespace SpectTest.ViewModels
{
    public class SignInVM : BaseViewModel
    {
        public string _username = "", _password = "";

        public SignInVM()
        {
            CreateAccountCommand = new Command(async () => await CreateAccount());
            GetUserCommand = new Command(async () => await SignIn());
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChangedEventHandler("Username");
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChangedEventHandler("Password");
            }
        }
        public async Task CreateAccount()
        {
            await _pageServices.PushAsync(new CreateAccountPage());
        }
        public string UserLogged
        {
            get => Settings.UserLogged;
            set
            {
                if (Settings.UserLogged == value)
                    return;

                Settings.UserLogged = value;
                OnPropertyChangedEventHandler("UserLogged");
            }

        }

        public async Task SignIn()
        {
            string[] response = await DBServices.GetUser(Username, Password);
            if(response[0] == "ERROR")
            {
                await _pageServices.DisplayAlert("Warning", response[1], "OK");
                return;
            }
            //await _pageServices.PushAsync(new SuccessfulSignInPage(response[1]));
            UserLogged = response[1];
            App.Current.MainPage = new NavigationPage(new SuccessfulSignInPage());

     }
        public Command CreateAccountCommand { get; set; }
        public Command GetUserCommand { get; set; }
    }
}
