using Redoubt.Core.Engine.Objects.Items;
using Redoubt.Core.Engine.Objects.Types;
using System.Collections.Generic;

namespace Redoubt.Core.Engine.Objects.Units
{
    public class NPC : IUnit
    {
        public UnitType UnitType { get; set; }
        public string Name { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Hitpoints { get; set; }
        public int Magicpoints { get; set; }
        public int Armor { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Stamina { get; set; }
        public int Magic { get; set; }
        public Dictionary<string, Consumable> Bag { get; set; }
        public Dictionary<string, Equippable> Inventory { get; set; }
    }
}
