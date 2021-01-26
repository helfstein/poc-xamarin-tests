using AllTests.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AllTests.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersPage : ContentPage {
        
        BasePageViewModel viewModel;
        public CharactersPage() {
            InitializeComponent();
            viewModel = new CharactersPageModel();
            BindingContext = viewModel;
            
            RotateElement(loading, CancellationToken.None).ConfigureAwait(false);
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            viewModel.OnAppearing().ConfigureAwait(false);
        }

        private async Task RotateElement(VisualElement element, CancellationToken cancellation) {
            while (!cancellation.IsCancellationRequested) {
                await element.ScaleTo(2, 800, Easing.Linear);
                await element.ScaleTo(1, 800); // reset to initial position
            }
        }

    }
}