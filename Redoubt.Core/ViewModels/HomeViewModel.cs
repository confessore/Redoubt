using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public ICommand NavigateExplore
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ExploreViewModel>());
            }
        }

        public ICommand NavigateShop
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ShopViewModel>());
            }
        }

        public ICommand NavigateInventory
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<InventoryViewModel>());
            }
        }

        public ICommand NavigateStats
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<StatsViewModel>());
            }
        }
    }
}
