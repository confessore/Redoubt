using Redoubt.Models;
using System.Collections.ObjectModel;

namespace Redoubt.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        public StatsViewModel()
        {
            Equipment = App.Player.Equipment;
            Name = App.Player.Name;
            Strength = App.Player.Strength;
            Dexterity = App.Player.Dexterity;
            Intellect = App.Player.Intellect;
            Vitality = App.Player.Vitality;
            Attack = App.Player.Attack;
            Will = App.Player.Will;
            Hit = App.Player.Hit;
            Crit = App.Player.Crit;
            Avoid = App.Player.Avoid;
            Mitigate = App.Player.Mitigate;
            Health = App.Player.Health;
            Spirit = App.Player.Spirit;
            foreach (var item in Equipment)
            {
                Strength += item.Strength;
                Dexterity += item.Dexterity;
                Intellect += item.Intellect;
                Vitality += item.Vitality;
                Attack += item.Attack;
                Will += item.Will;
                Hit += item.Hit;
                Crit += item.Crit;
                Avoid += item.Avoid;
                Mitigate += item.Mitigate;
            }
        }

        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        int strength;
        public int Strength
        {
            get => strength;
            set
            {
                strength = value;
                OnPropertyChanged();
            }
        }

        int dexterity;
        public int Dexterity
        {
            get => dexterity;
            set
            {
                dexterity = value;
                OnPropertyChanged();
            }
        }

        int intellect;
        public int Intellect
        {
            get => intellect;
            set
            {
                intellect = value;
                OnPropertyChanged();
            }
        }

        int vitality;
        public int Vitality
        {
            get => vitality;
            set
            {
                vitality = value;
                OnPropertyChanged();
            }
        }

        int attack;
        public int Attack
        {
            get => attack;
            set
            {
                attack = value;
                OnPropertyChanged();
            }
        }

        int will;
        public int Will
        {
            get => will;
            set
            {
                will = value;
                OnPropertyChanged();
            }
        }

        int hit;
        public int Hit
        {
            get => hit;
            set
            {
                hit = value;
                OnPropertyChanged();
            }
        }

        int crit;
        public int Crit
        {
            get => crit;
            set
            {
                crit = value;
                OnPropertyChanged();
            }
        }

        int avoid;
        public int Avoid
        {
            get => avoid;
            set
            {
                avoid = value;
                OnPropertyChanged();
            }
        }

        int mitigate;
        public int Mitigate
        {
            get => mitigate;
            set
            {
                mitigate = value;
                OnPropertyChanged();
            }
        }

        int health;
        public int Health
        {
            get => health;
            set
            {
                health = value;
                OnPropertyChanged();
            }
        }

        int spirit;
        public int Spirit
        {
            get => spirit;
            set
            {
                spirit = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Item> equipment;
        public ObservableCollection<Item> Equipment
        {
            get => equipment;
            set
            {
                equipment = value;
                OnPropertyChanged();
            }
        }
    }
}
