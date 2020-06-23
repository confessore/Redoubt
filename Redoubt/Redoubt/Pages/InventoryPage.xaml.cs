using Redoubt.Models;
using Redoubt.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Redoubt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryPage : ContentPage
    {
        InventoryViewModel ViewModel { get; }

        public InventoryPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = ViewModel = new InventoryViewModel();
            ViewModel.Navigation = Navigation;
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e) =>
            await Navigation.PushAsync(new InventoryDetailPage((Item)e.Item));
    }
}