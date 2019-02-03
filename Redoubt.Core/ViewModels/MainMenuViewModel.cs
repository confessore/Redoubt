﻿using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class MainMenuViewModel : MvxViewModel
    {
        public ICommand NavBack
        {
            get => new MvxCommand(() => Close(this));
        }

        public ICommand NavigateNewGame
        {
            get => new MvxCommand(() => ShowViewModel<NamingViewModel>());
        }

        public ICommand NavigateLoadGame
        {
            get =>
                new MvxCommand(() =>
                {
                    //await App.UtilityModule.LoadGame();
                    ShowViewModel<HomeViewModel>();
                    Close(this);
                });
        }
    }
}
