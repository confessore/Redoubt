using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class InventoryViewModel : MvxViewModel
    {
        readonly IMvxNavigationService nav;

        public InventoryViewModel(IMvxNavigationService nav)
        {
            this.nav = nav;
        }
        
        public ICommand NavBack { get => new MvxCommand(() => Close(this)); }
        public ICommand Inspect { get => new MvxCommand<Item>(x => nav.Navigate<InspectItemViewModel, Item>(x)); }

        public MvxObservableCollection<Item> Inventory
        {
            get => new MvxObservableCollection<Item>(App.Player.Inventory);
        }
    }
}
