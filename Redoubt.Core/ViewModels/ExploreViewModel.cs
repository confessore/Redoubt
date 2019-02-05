using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class ExploreViewModel : MvxViewModel
    {
        /*public string Name
        {
            private get => App.Player.Name;
            set
            {
                Name = value;
                RaisePropertyChanged(() => Name);
            }
        }*/

        public ICommand NavBack
        {
            get => new MvxCommand(() => Close(this));
        }

        public ICommand Attack
        {
            get =>
                new MvxCommand(() =>
                {

                });
        }
    }
}
