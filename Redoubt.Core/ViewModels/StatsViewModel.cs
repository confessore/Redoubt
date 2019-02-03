using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class StatsViewModel : MvxViewModel
    {
        public string Name
        {
            private get => App.Player.Name;
            set
            {
                Name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public int Level
        {
            private get => App.Player.Level;
            set
            {
                Level = value;
                RaisePropertyChanged(() => Level);
            }
        }

        /*public int Maximum
        {
            private get => App.Player.Maximum;
            set
            {
                Maximum = value;
                RaisePropertyChanged(() => Maximum);
            }
        }

        public int Hitpoints
        {
            private get => App.Player.Hitpoints;
            set
            {
                Hitpoints = value;
                RaisePropertyChanged(() => Hitpoints);
            }
        }

        public int Magicpoints
        {
            private get => App.Player.Magicpoints;
            set
            {
                Magicpoints = value;
                RaisePropertyChanged(() => Magicpoints);
            }
        }

        public int Armor
        {
            private get => App.Player.Armor;
            set
            {
                Armor = value;
                RaisePropertyChanged(() => Armor);
            }
        }

        public int Strength
        {
            private get => App.Player.Strength;
            set
            {
                Strength = value;
                RaisePropertyChanged(() => Strength);
            }
        }

        public int Dexterity
        {
            private get => App.Player.Dexterity;
            set
            {
                Dexterity = value;
                RaisePropertyChanged(() => Dexterity);
            }
        }

        public int Stamina
        {
            private get => App.Player.Stamina;
            set
            {
                Stamina = value;
                RaisePropertyChanged(() => Stamina);
            }
        }

        public int Magic
        {
            private get => App.Player.Magic;
            set
            {
                Magic = value;
                RaisePropertyChanged(() => Magic);
            }
        }*/

        public ICommand NavBack
        {
            get => new MvxCommand(() => Close(this));
        }
    }
}
