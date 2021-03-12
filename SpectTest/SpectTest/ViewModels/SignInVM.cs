using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using SpectTest.Views;
using SpectTest.Services;

namespace SpectTest.ViewModels
{
    public class SignInVM
    {
        private IPageServices _pageServices = new PageServices();
        public SignInVM()
        {
            CreateAccountCommand = new Command(async () => await CreateAccount());
        }

        public async Task CreateAccount()
        {
            await _pageServices.PushAsync(new CreateAccountPage());
        }

        public Command CreateAccountCommand { get; set; }
    }
}
