using System;
using System.ComponentModel;
using Xamarin.Forms;
using SpectTest.DB;
using SpectTest.Views;
using SpectTest.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpectTest.ViewModels
{
    public class CreateAccountVM : INotifyPropertyChanged
    {
        public string _firstName = "", _lastName = "", _username = "", _password = "", _phone = "";
        public DateTime _date;
        public bool _enableBtn = false;

        private IPageServices _pageServices = new PageServices();
        public ICommand InsertUserCommand { get; }

        public CreateAccountVM()
        {
            InsertUserCommand = new Command(async () => await InsertUser());

        }

        async Task InsertUser()
        {
            await DBServices.AddUser(FirstName, LastName, Phone, Username, Password, Date);
            await _pageServices.DisplayAlert("Warning", "New user added", "Ok");
            await _pageServices.PopAsync();
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChangedEventHandler("FirstName");
                btnCreateAccountValidation();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChangedEventHandler("LastName");
                btnCreateAccountValidation();
            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChangedEventHandler("Phone");
                btnCreateAccountValidation();
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChangedEventHandler("Username");
                btnCreateAccountValidation();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChangedEventHandler("Password");
                btnCreateAccountValidation();
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChangedEventHandler("Date");
                btnCreateAccountValidation();
            }
        }

        public bool EnableBtn
        {
            get => _enableBtn;
            set
            {
                _enableBtn = value;
                OnPropertyChangedEventHandler("EnableBtn");
            }
        }       

        void btnCreateAccountValidation()
        {
            if (FirstName != "" && LastName != "" && Phone != "" && Username != "" && Password != "" && Date != null)
            {
                EnableBtn = true;
            } else
            {
                EnableBtn = false;
            }
        }

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
