using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class MainMenuViewModel : MvxViewModel
    {
        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public ICommand NavigateNewGame
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<HomeViewModel>());
            }
        }

        public ICommand NavigateLoadGame
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<HomeViewModel>());
            }
        }
    }
}
