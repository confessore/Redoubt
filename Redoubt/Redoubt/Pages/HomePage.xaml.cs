using Redoubt.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Redoubt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomeViewModel ViewModel { get; }

        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = ViewModel = new HomeViewModel();
            ViewModel.Navigation = Navigation;
        }

        async void OnInventory(object sender, EventArgs args) =>
            await Navigation.PushAsync(new InventoryPage());

        async void OnEquipment(object sender, EventArgs args) =>
            await Navigation.PushAsync(new EquipmentPage());

        async void OnStats(object sender, EventArgs args) =>
            await Navigation.PushAsync(new StatsPage());
    }
}