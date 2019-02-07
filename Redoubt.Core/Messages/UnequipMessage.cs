using MvvmCross.Plugins.Messenger;

namespace Redoubt.Core.Messages
{
    public class UnequipMessage : MvxMessage
    {
        public UnequipMessage(object sender, Item item)
            : base(sender)
        {
            Item = item;
        }

        public Item Item { get; set; }
    }
}
