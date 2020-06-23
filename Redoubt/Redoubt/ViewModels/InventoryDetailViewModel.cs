using Redoubt.Models;

namespace Redoubt.ViewModels
{
    public class InventoryDetailViewModel : BaseViewModel
    {
        public InventoryDetailViewModel(Item item)
        {
            Item = item;
        }

        Item item;
        public Item Item
        {
            get => item;
            set
            {
                item = value;
                OnPropertyChanged();
            }
        }
    }
}
