using MvvmCross.Core.ViewModels;
using Redoubt.Core.Statics;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class MainMenuViewModel : MvxViewModel
    {
        public ICommand NavBack { get => new MvxCommand(() => Close(this)); }
        public ICommand NavigateNewGame
        {
            get =>
                new MvxCommand(() =>
                {
                    ShowViewModel<NamingViewModel>();
                    Close(this);
                });
        }

        public ICommand NavigateLoadGame
        {
            get => 
                new MvxCommand(() =>
                {
                    State.Instance.Load();
                    ShowViewModel<HomeViewModel>();
                    Close(this);
                });
        }
    }
}
