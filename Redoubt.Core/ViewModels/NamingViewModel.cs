using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class NamingViewModel : MvxViewModel
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public ICommand NavBack
        {
            get => new MvxCommand(() => Close(this));
        }

        public ICommand Save
        {
            get => 
                new MvxCommand(async () =>
                {
                    if (Name != null)
                    {
                        await App.Utilities.NewGame(Name);
                        ShowViewModel<HomeViewModel>();
                    }

                    Close(this);
                });
        }
    }
}
