using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Redoubt.Core.Messages;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class EquipmentInspectViewModel : MvxViewModel<Item>
    {
        readonly IMvxMessenger messenger;

        public EquipmentInspectViewModel(IMvxMessenger messenger)
        {
            this.messenger = messenger;
        }

        public ICommand NavBack { get => new MvxCommand(() => Close(this)); }

        public Item Item { get; set; } = new Item();
        bool unequip;

        public override void Prepare(Item item)
        {
            Item = item;
        }

        public ICommand Unequip
        {
            get =>
                new MvxCommand(() =>
                {
                    if (!unequip)
                    {
                        unequip = true;
                        messenger.Publish(new UnequipMessage(this, Item));
                        Close(this);
                    }
                });
        }
    }
}
