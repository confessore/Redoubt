using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Redoubt.Core.Messages;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class InventoryViewModel : MvxViewModel
    {
        readonly IMvxNavigationService nav;
        readonly MvxSubscriptionToken token;

        public InventoryViewModel(IMvxNavigationService nav, IMvxMessenger messenger)
        {
            this.nav = nav;
            token = messenger.Subscribe<EquipMessage>(OnEquip);
            inventory = new MvxObservableCollection<Item>(App.Player.Inventory);
        }
        
        public ICommand NavBack { get => new MvxCommand(() => Close(this)); }
        public ICommand Inspect { get => new MvxCommand<Item>(x => nav.Navigate<InspectItemViewModel, Item>(x)); }

        MvxObservableCollection<Item> inventory;
        public MvxObservableCollection<Item> Inventory
        {
            get => inventory;
            set
            {
                inventory = value;
                RaisePropertyChanged(() => Inventory);
            }
        }

        void OnEquip(EquipMessage msg)
        {
            Inventory.Remove(msg.Item);
            App.Player.Inventory.Remove(msg.Item);
        }
    }
}
