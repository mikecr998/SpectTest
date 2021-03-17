using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using SpectTest.Views;
using SpectTest.Services;
using System.ComponentModel;
using SpectTest.DB;
using SpectTest.Models;

namespace SpectTest.ViewModels
{
    public class SignInVM : INotifyPropertyChanged
    {
        private User userClass;
        public string _username = "", _password = "";
        private IPageServices _pageServices = new PageServices();

        public SignInVM()
        {
            CreateAccountCommand = new Command(async () => await CreateAccount());
            GetUserCommand = new Command(async () => await GetUser());
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

        public async Task GetUser()
        {
            string[] response = await DBServices.GetUser(Username, Password);
            if(response[0] == "ERROR")
            {
                await _pageServices.DisplayAlert("Warning", response[1], "OK");
                return;
            }
            await _pageServices.PushAsync(new SuccessfulSignInPage(response[1]));
        }
        public Command CreateAccountCommand { get; set; }
        public Command GetUserCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChangedEventHandler(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
