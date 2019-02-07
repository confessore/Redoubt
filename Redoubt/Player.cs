using System;
using System.Collections.Generic;

namespace Redoubt
{
    public class Player
    {
        public Player()
        {

        }

        public Player(string name)
        {
            Guid = Guid.NewGuid();
            Name = name;
            Experience = 1;
            Level = Experience;
            Strength = 5;
            Dexterity = 5;
            Intellect = 5;
            Vitality = 5;
            Attack = 5;
            Will = 5;
            Hit = 5;
            Crit = 5;
            Avoid = 5;
            Mitigate = 5;
            CurrentHealth = Vitality * 10;
            CurrentSpirit = Intellect * 10;
            Equipment = new List<Item>();
            Inventory = new List<Item>();
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public int CurrentHealth { get; set; }
        public int CurrentSpirit { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intellect { get; set; }
        public int Vitality { get; set; }
        public int Attack { get; set; }
        public int Will { get; set; }
        public int Hit { get; set; }
        public int Crit { get; set; }
        public int Avoid { get; set; }
        public int Mitigate { get; set; }
        public List<Item> Equipment { get; set; }
        public List<Item> Inventory { get; set; }
    }
}
