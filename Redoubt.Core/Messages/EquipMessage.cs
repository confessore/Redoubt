using MvvmCross.Plugins.Messenger;

namespace Redoubt.Core.Messages
{
    public class EquipMessage : MvxMessage
    {
        public EquipMessage(object sender, Item item)
            :base(sender)
        {
            Item = item;
        }

        public Item Item { get; set; }
    }
}
