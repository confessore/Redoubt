using Redoubt.Core.Engine.Objects.Items;
using Redoubt.Core.Engine.Objects.Interfaces.Types;

namespace Redoubt.Core.Engine.Objects.Databases
{
    public class ConsumableDatabase
    {
        public Consumable LesserHealthPotion
        {
            get => 
                new Consumable
                {
                    ItemType = ItemType.Potion,
                    Name = "Lesser Health Potion",
                    Minimum = 0,
                    Maximum = 0,
                    Hitpoints = 50,
                    Magicpoints = 0,
                    Armor = 0,
                    Strength = 0,
                    Dexterity = 0,
                    Stamina = 0,
                    Magic = 0
                };
        }
    }
}
