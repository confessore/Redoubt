using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public ICommand NavigateLogin
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<MainMenuViewModel>());
            }
        }
    }
}
