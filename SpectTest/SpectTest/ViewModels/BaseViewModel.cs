using SpectTest.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SpectTest.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IPageServices _pageServices = new PageServices();
        public event PropertyChangedEventHandler PropertyChanged;
        public BaseViewModel()
        {

        }        
        public void OnPropertyChangedEventHandler(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
