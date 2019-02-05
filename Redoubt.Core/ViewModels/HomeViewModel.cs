using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public ICommand NavBack { get => new MvxCommand(() => Close(this)); }
        public ICommand NavigateExplore { get => new MvxCommand(() => ShowViewModel<ExploreViewModel>()); }
        public ICommand NavigateShop { get => new MvxCommand(() => ShowViewModel<ShopViewModel>()); }
        public ICommand NavigateInventory{ get => new MvxCommand(() => ShowViewModel<InventoryViewModel>()); }
        public ICommand NavigateStats { get => new MvxCommand(() => ShowViewModel<StatsViewModel>()); }
    }
}
