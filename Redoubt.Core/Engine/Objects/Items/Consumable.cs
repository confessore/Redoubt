using Redoubt.Core.Engine.Objects.Interfaces;
using Redoubt.Core.Engine.Objects.Interfaces.Types;

namespace Redoubt.Core.Engine.Objects.Items
{
    public class Consumable : IItem
    {
        public ItemType ItemType { get; set; }
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
    }
}
