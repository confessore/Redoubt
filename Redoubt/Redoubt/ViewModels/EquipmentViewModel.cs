using Redoubt.Extensions;
using Redoubt.Models;
using Redoubt.Pages;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Redoubt.ViewModels
{
    public class EquipmentViewModel : BaseViewModel
    {
        public EquipmentViewModel()
        {
            Equipment = App.Player.Equipment;
            MessagingCenter.Subscribe<EquipmentDetailPage, Item>(this, "Unequip", (sender, arg) =>
            {
                Equipment.Remove(arg);
            });
        }

        ObservableCollection<Item> equipment;
        public ObservableCollection<Item> Equipment
        {
            get => equipment;
            set
            {
                equipment = value.OrderBySlot();
                OnPropertyChanged();
            }
        }
    }
}
