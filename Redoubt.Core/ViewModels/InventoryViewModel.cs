using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class InventoryViewModel : MvxViewModel
    {
        public ICommand NavBack
        {
            get => new MvxCommand(() => Close(this));
        }

        public List<Item> Inventory
        {
            get => App.Player.Inventory;
        }
    }
}
