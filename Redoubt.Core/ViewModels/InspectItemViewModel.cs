using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class InspectItemViewModel : MvxViewModel<Item>
    {
        public Item Item { get; set; } = new Item();

        public ICommand NavBack
        {
            get => new MvxCommand(() => Close(this));
        }

        public override void Prepare(Item item)
        {
            Item = item;
        }
    }
}
