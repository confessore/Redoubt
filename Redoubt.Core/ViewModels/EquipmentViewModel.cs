using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Redoubt.Core.Dynamics;
using Redoubt.Core.Messages;
using System;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    class EquipmentViewModel : MvxViewModel, IDisposable
    {
        readonly IMvxNavigationService nav;
        readonly IMvxMessenger messenger;
        readonly MvxSubscriptionToken unequipToken;

        public EquipmentViewModel(IMvxNavigationService nav, IMvxMessenger messenger)
        {
            this.nav = nav;
            this.messenger = messenger;
            unequipToken = messenger.Subscribe<UnequipMessage>(OnUnequip);
            equipment = new MvxObservableCollection<Item>(App.Player.Equipment);
        }

        public ICommand NavBack { get => new MvxCommand(() => Close(this)); }
        public ICommand Inspect { get => new MvxCommand<Item>(x => nav.Navigate<EquipmentInspectViewModel, Item>(x)); }

        MvxObservableCollection<Item> equipment;
        public MvxObservableCollection<Item> Equipment
        {
            get => equipment;
            set
            {
                equipment = value;
                RaisePropertyChanged(() => Equipment);
            }
        }

        void OnUnequip(UnequipMessage msg)
        {
            Equipment.Remove(msg.Item);
            App.Player.Equipment.Remove(msg.Item);
            App.Player.Inventory.Add(msg.Item);
            new State().Save();
        }

        public void Dispose()
        {
            messenger.Unsubscribe<UnequipMessage>(unequipToken);
        }
    }
}
