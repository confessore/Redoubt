using Redoubt.Models;

namespace Redoubt.ViewModels
{
    public class EquipmentDetailViewModel : BaseViewModel
    {
        public EquipmentDetailViewModel(Item item)
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
