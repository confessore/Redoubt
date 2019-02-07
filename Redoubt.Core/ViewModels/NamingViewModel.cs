using MvvmCross.Core.ViewModels;
using Redoubt.Core.Dynamics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class NamingViewModel : MvxViewModel
    {
        public ICommand NavBack { get => new MvxCommand(() => Close(this)); }

        public ICommand Save
        {
            get =>
                new MvxAsyncCommand(async () =>
                {
                    if (Name != null)
                    {
                        App.Player = new Player(Name);
                        for (int x = 0; x < 10; x++)
                            await Task.Run(() => new Thread(() => App.Player.Inventory.Add(new Item())).Start());
                        new State().Save();
                        ShowViewModel<HomeViewModel>();
                    }
                    Close(this);
                });
        }

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
    }
}
