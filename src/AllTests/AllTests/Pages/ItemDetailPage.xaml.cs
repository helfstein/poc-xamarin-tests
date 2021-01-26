using AllTests.PageModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AllTests.Pages {
    public partial class ItemDetailPage : ContentPage {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}