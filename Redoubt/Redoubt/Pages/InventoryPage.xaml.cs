using Redoubt.Models;
using Redoubt.ViewModels;
using System;
using System.Linq;
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

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                ViewModel.Inventory = App.Player.Inventory;
                foreach (var item in ViewModel.Inventory.ToList())
                {
                    if ((int)item.Slot != selectedIndex)
                        ViewModel.Inventory.Remove(item);
                }
            }
        }

        void OnFilterCleared(object sender, EventArgs args)
        {
            ViewModel.Inventory = App.Player.Inventory;
            ViewModel.SelectedIndex = -1;
        }
    }
}