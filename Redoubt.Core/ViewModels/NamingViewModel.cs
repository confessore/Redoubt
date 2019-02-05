using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using Redoubt.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
                        App.Player = new Player
                        {
                            Name = Name,
                            Level = 1,
                            Strength = 10,
                            Dexterity = 10,
                            Intellect = 10,
                            Vitality = 100,
                            Attack = 0,
                            Will = 0,
                            Hit = 0,
                            Crit = 0,
                            Avoid = 0,
                            Mitigate = 0,
                            Equipment = new List<KeyValuePair<Slot, Item>>(),
                            Inventory = new List<Item>()
                        };
                        for (int x = 0; x < 10; x++)
                            await Task.Run(() => new Thread(() => App.Player.Inventory.Add(new Item())).Start());
                        var json = JsonConvert.SerializeObject(App.Player);
                        File.WriteAllText(Assembly.GetExecutingAssembly().ExtJumpUp(1) + "/Item", json);
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
