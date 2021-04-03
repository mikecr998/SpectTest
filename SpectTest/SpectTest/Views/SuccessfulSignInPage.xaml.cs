using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SpectTest.ViewModels;

namespace SpectTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessfulSignInPage : ContentPage
    {
        public SuccessfulSignInPage()
        {
            InitializeComponent();
            BindingContext = new SuccessfulSignInVM();
        }
    }
}