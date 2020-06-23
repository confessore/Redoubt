using Redoubt.Models;
using Redoubt.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Redoubt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquipmentDetailPage : ContentPage
    {
        EquipmentDetailViewModel ViewModel { get; }

        public EquipmentDetailPage(Item item)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = ViewModel = new EquipmentDetailViewModel(item);
            ViewModel.Navigation = Navigation;
        }

        async void OnUnequip(object sender, EventArgs args)
        {
            App.Player.Equipment.Remove(ViewModel.Item);
            App.Player.Inventory.Add(ViewModel.Item);
            MessagingCenter.Send(this, "Unequip", ViewModel.Item);
            await Navigation.PopAsync();
        }
    }
}