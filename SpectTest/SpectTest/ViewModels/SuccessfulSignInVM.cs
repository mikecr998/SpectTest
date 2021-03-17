using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SpectTest.ViewModels
{
    public class SuccessfulSignInVM : INotifyPropertyChanged
    {
       public string _username; 
       public SuccessfulSignInVM(string username)
        {
            this._username = username;
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
