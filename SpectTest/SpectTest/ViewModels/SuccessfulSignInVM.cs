using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using SpectTest.Views;
using Xamarin.Forms;
using SpectTest.Services;

namespace SpectTest.ViewModels
{
    public class SuccessfulSignInVM : BaseViewModel
    {
       public string _username;
        public SuccessfulSignInVM()
        {
            this._username = "Welcome " + Settings.UserLogged;
            SignOutCommand = new Command(SignOut);
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

        public void SignOut()
        {
            Settings.RemoveUserLogged();
            App.Current.MainPage = new NavigationPage(new SignInPage());
        }

        public Command SignOutCommand { get; }
    }
}
