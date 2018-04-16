using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class ShopViewModel : MvxViewModel
    {
        public ICommand NavBack
        {
            get => new MvxCommand(() => Close(this));
        }
    }
}
