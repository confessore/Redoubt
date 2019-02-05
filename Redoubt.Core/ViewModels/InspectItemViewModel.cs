using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Redoubt.Core.Messages;
using System.Collections.Generic;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class InspectItemViewModel : MvxViewModel<Item>
    {
        readonly IMvxMessenger messenger;

        public InspectItemViewModel(IMvxMessenger messenger)
        {
            this.messenger = messenger;
        }

        public ICommand NavBack { get => new MvxCommand(() => Close(this)); }

        public InventoryViewModel Inv { get; set; }
        public Item Item { get; set; } = new Item();

        public override void Prepare(Item item)
        {
            Item = item;
        }

        public ICommand Equip
        {
            get =>
                new MvxCommand(() =>
                {
                    messenger.Publish(new EquipMessage(this, Item));
                    App.Player.Equipment.Add(new KeyValuePair<Slot, Item>(Item.Slot, Item));
                    Close(this);
                });
        }
    }
}
