using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Redoubt.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class InventoryInspectViewModel : MvxViewModel<Item>
    {
        readonly IMvxMessenger messenger;

        public InventoryInspectViewModel(IMvxMessenger messenger)
        {
            this.messenger = messenger;
        }

        public ICommand NavBack { get => new MvxCommand(() => Close(this)); }

        public Item Item { get; set; } = new Item();
        bool equip;

        public override void Prepare(Item item)
        {
            Item = item;
        }

        public ICommand Equip
        {
            get =>
                new MvxCommand(() =>
                {
                    if (!equip)
                    {
                        equip = true;
                        messenger.Publish(new EquipMessage(this, Item));
                        Close(this);
                    }
                });
        }
    }
}
