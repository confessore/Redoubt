using Redoubt.Core.Engine.Objects.Items;
using Redoubt.Core.Engine.Objects.Types;

namespace Redoubt.Core.Engine.Objects.Databases
{
    public class EquippableDatabase
    {
        public Equippable ShortSword
        {
            get => 
                new Equippable
                {
                    ItemType = ItemType.MainHand,
                    Name = "Short Sword",
                    Minimum = 1,
                    Maximum = 3,
                    Hitpoints = 0,
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
