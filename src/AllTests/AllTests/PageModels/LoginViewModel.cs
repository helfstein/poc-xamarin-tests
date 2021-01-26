using AllTests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AllTests.PageModels {
    public class LoginViewModel : BasePageViewModel {
        public ICommand LoginCommand { get; }

        public LoginViewModel() {
            LoginCommand = new Command(OnLoginLoginCommand);
        }

        private async void OnLoginLoginCommand() {
           
            if (!App.Current.Properties.ContainsKey("IsAuthenticated")) {
                App.Current.Properties["IsAuthenticated"] = true;
                await App.Current.SavePropertiesAsync();
            }

            await Shell.Current.GoToAsync($"//{nameof(CharactersPage)}");
        }
    }
}
