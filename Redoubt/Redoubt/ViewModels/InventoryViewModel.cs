using Redoubt.Extensions;
using Redoubt.Models;
using Redoubt.Pages;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Redoubt.ViewModels
{
    public class InventoryViewModel : BaseViewModel
    {
        public InventoryViewModel()
        {
            Inventory = App.Player.Inventory;
            MessagingCenter.Subscribe<InventoryDetailPage, Item>(this, "Equip", (sender, arg) =>
            {
                Inventory.Remove(arg);
            });
            MessagingCenter.Subscribe<InventoryDetailPage, Item>(this, "Swap", (sender, arg) =>
            {
                Inventory.Add(arg);
            });
        }

        ObservableCollection<Item> inventory;
        public ObservableCollection<Item> Inventory
        {
            get => inventory;
            set
            {
                inventory = value.OrderBySlot();
                OnPropertyChanged();
            }
        }
    }
}
