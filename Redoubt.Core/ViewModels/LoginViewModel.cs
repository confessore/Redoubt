using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        public ICommand NavBack
        {
            get => new MvxCommand(() => Close(this));
        }

        public ICommand NavigateLogin
        {
            get => new MvxCommand(() => ShowViewModel<MainMenuViewModel>());
        }
    }
}
