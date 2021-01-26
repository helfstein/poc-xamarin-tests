using AllTests.Pages;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AllTests.PageModels {
    public class ConfigViewModel : BasePageViewModel {
        public ConfigViewModel() {
            Title = "About";
            LogoutCommand = new Command(OnLogoutCommand);
        }

        private async void OnLogoutCommand(object obj) {
            try {
                if (IsBusy) return;
                IsBusy = true;
                if (App.Current.Properties.ContainsKey("IsAuthenticated")) {
                    App.Current.Properties.Remove("IsAuthenticated");
                    await App.Current.SavePropertiesAsync();
                }
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                IsBusy = false;
            }
           
        }

        public ICommand LogoutCommand { get; }
        
    }
}