using AllTests.Services;
using AllTests.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace AllTests {
    public partial class App : Application {

        public App() {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        private async Task InitAppDataAsync() {
           
            if (App.Current.Properties.ContainsKey("IsAuthenticated") && (bool)App.Current.Properties["IsAuthenticated"]) {
                await Shell.Current.GoToAsync($"//{nameof(CharactersPage)}");
            }

        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
