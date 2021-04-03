using System;
using Xamarin.Forms;
using SpectTest.DB;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace SpectTest.ViewModels
{
    public class CreateAccountVM : BaseViewModel
    {
        public string _firstName = "", _lastName = "", _username = "", _password = "", _phone = "";
        public DateTime _date;
        public bool _enableBtn = false, _firstNameWarning = false, _lastNameWarning = false;

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
                FirstNameValidation();
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
                LastNameValidation();
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

        public bool FirstNameWarning
        {
            get => _firstNameWarning;
            set
            {
                _firstNameWarning = value;
                OnPropertyChangedEventHandler("FirstNameWarning");
            }
        }
        public bool LastNameWarning
        {
            get => _lastNameWarning;
            set
            {
                _lastNameWarning = value;
                OnPropertyChangedEventHandler("LastNameWarning");
            }
        }

        void btnCreateAccountValidation()
        {
            if (FirstName != "" && LastName != "" && Phone != "" && Username != "" && Password != "" && Date != null && !FirstNameValidation() && !LastNameValidation())
            {
                EnableBtn = true;
            } else
            {
                EnableBtn = false;
            }
        }
        public bool FirstNameValidation()
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            if (regex.IsMatch(FirstName) || FirstName == "")
            {
                FirstNameWarning = false;
                return false;
            }
            else
            {
                FirstNameWarning = true;
                return true;
            }            
        }
        public bool LastNameValidation()
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            if (regex.IsMatch(LastName) || LastName == "")
            {
                LastNameWarning = false;
                return false;
            }
            else
            {
                LastNameWarning = true;
                return true;
            }
        }
    }
}
