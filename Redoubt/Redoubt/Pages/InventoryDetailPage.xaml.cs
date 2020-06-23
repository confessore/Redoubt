using Redoubt.Models;
using Redoubt.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Redoubt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryDetailPage : ContentPage
    {
        InventoryDetailViewModel ViewModel { get; }

        public InventoryDetailPage(Item item)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = ViewModel = new InventoryDetailViewModel(item);
            ViewModel.Navigation = Navigation;
        }

        async void OnEquip(object sender, EventArgs args)
        {
            var existingItem = App.Player.Equipment.FirstOrDefault(x => x.Slot == ViewModel.Item.Slot);
            if (existingItem != null)
            {
                App.Player.Equipment.Remove(existingItem);
                App.Player.Inventory.Add(existingItem);
                MessagingCenter.Send(this, "Swap", existingItem);
            }
            App.Player.Inventory.Remove(ViewModel.Item);
            App.Player.Equipment.Add(ViewModel.Item);
            MessagingCenter.Send(this, "Equip", ViewModel.Item);
            await Navigation.PopAsync();
        }
    }
}