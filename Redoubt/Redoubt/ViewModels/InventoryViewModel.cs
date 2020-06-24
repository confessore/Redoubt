using Redoubt.Enums;
using Redoubt.Extensions;
using Redoubt.Models;
using Redoubt.Pages;
using System;
using System.Collections.Generic;
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
            foreach (var slot in Enum.GetNames(typeof(Slot)))
                Slots.Add(slot);
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


        public List<string> Slots { get; set; } = new List<string>();

        int selectedIndex = -1;
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                selectedIndex = value;
                OnPropertyChanged();
            }
        }
    }
}
