using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class InventoryViewModel : MvxViewModel
    {
        public ICommand NavBack
        {
            get => new MvxCommand(() => Close(this));
        }
    }
}
