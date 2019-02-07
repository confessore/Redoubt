using MvvmCross.Core.ViewModels;
using Redoubt.Core.Statics;
using System;
using System.Linq;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class StatsViewModel : MvxViewModel
    {
        public ICommand NavBack { get => new MvxCommand(() => Close(this)); }

        Stats Stats = new Stats();

        public Guid Guid
        {
            private get => App.Player.Guid;
            set
            {
                Guid = value;
                RaisePropertyChanged(() => Guid);
            }
        }

        public string Name
        {
            private get => App.Player.Name;
            set
            {
                Name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public int Experience
        {
            private get => App.Player.Experience;
            set
            {
                Experience = value;
                RaisePropertyChanged(() => Experience);
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

        public int CurrentHealth
        {
            private get
            {
                if (App.Player.CurrentHealth > TotalHealth)
                {
                    App.Player.CurrentHealth = TotalHealth;
                    return TotalHealth;
                }
                return App.Player.CurrentHealth;
            }
            set
            {
                CurrentHealth = value;
                RaisePropertyChanged(() => CurrentHealth);
            }
        }

        public int TotalHealth
        {
            private get => Vitality * 10;
            set
            {
                TotalHealth = value;
                RaisePropertyChanged(() => TotalHealth);
            }
        }

        public string Health
        {
            private get => $"{CurrentHealth} / {TotalHealth}";
            set
            {
                Health = value;
                RaisePropertyChanged(() => Health);
            }
        }

        public int CurrentSpirit
        {
            private get
            {
                if (App.Player.CurrentSpirit > TotalSpirit)
                {
                    App.Player.CurrentSpirit = TotalSpirit;
                    return TotalSpirit;
                }
                return App.Player.CurrentSpirit;
            }
            set
            {
                CurrentHealth = value;
                RaisePropertyChanged(() => CurrentHealth);
            }
        }

        public int TotalSpirit
        {
            private get => Intellect * 10;
            set
            {
                TotalSpirit = value;
                RaisePropertyChanged(() => TotalSpirit);
            }
        }

        public string Spirit
        {
            private get => $"{CurrentSpirit} / {TotalSpirit}";
            set
            {
                Spirit = value;
                RaisePropertyChanged(() => Spirit);
            }
        }

        public int Strength
        {
            private get => Stats.Strength;
            set
            {
                Strength = value;
                RaisePropertyChanged(() => Strength);
            }
        }

        public int Dexterity
        {
            private get => Stats.Dexterity;
            set
            {
                Dexterity = value;
                RaisePropertyChanged(() => Dexterity);
            }
        }

        public int Intellect
        {
            private get => Stats.Intellect;
            set
            {
                Intellect = value;
                RaisePropertyChanged(() => Intellect);
            }
        }

        public int Vitality
        {
            private get => Stats.Vitality;
            set
            {
                Vitality = value;
                RaisePropertyChanged(() => Vitality);
            }
        }

        public int Attack
        {
            private get => Stats.Attack;
            set
            {
                Attack = value;
                RaisePropertyChanged(() => Attack);
            }
        }

        public int Will
        {
            private get => Stats.Will;
            set
            {
                Will = value;
                RaisePropertyChanged(() => Will);
            }
        }

        public int Hit
        {
            private get => Stats.Hit;
            set
            {
                Hit = value;
                RaisePropertyChanged(() => Hit);
            }
        }

        public int Crit
        {
            private get => Stats.Crit;
            set
            {
                Crit = value;
                RaisePropertyChanged(() => Crit);
            }
        }

        public int Avoid
        {
            private get => Stats.Avoid;
            set
            {
                Avoid = value;
                RaisePropertyChanged(() => Avoid);
            }
        }

        public int Mitigate
        {
            private get => Stats.Mitigate;
            set
            {
                Mitigate = value;
                RaisePropertyChanged(() => Mitigate);
            }
        }

        public int Equipment
        {
            private get => App.Player.Equipment.Count;
            set
            {
                Equipment = value;
                RaisePropertyChanged(() => Equipment);
            }
        }

        public int Inventory
        {
            private get => App.Player.Inventory.Count;
            set
            {
                Inventory = value;
                RaisePropertyChanged(() => Inventory);
            }
        }
    }
}
