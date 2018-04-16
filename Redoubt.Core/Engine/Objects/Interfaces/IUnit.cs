using Redoubt.Core.Engine.Objects.Interfaces.Types;
using Redoubt.Core.Engine.Objects.Items;
using System.Collections.Generic;

namespace Redoubt.Core.Engine.Objects.Interfaces
{
    public interface IUnit
    {
        UnitType UnitType { get; set; }
        string Name { get; set; }
        int Minimum { get; set; }
        int Maximum { get; set; }
        int Hitpoints { get; set; }
        int Magicpoints { get; set; }
        int Armor { get; set; }
        int Strength { get; set; }
        int Dexterity { get; set; }
        int Stamina { get; set; }
        int Magic { get; set; }
        Dictionary<string, Consumable> Bag { get; set; }
        Dictionary<string, Equippable> Inventory { get; set; }
    }
}
