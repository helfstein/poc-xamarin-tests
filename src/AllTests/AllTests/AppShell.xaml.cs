using AllTests.Pages;
using Xamarin.Forms;

namespace AllTests {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(CharacterDetailPage), typeof(CharacterDetailPage));

        }

    }
}
