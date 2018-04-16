using Redoubt.Core.Engine.Objects.Types;

namespace Redoubt.Core.Engine.Objects.Spells
{
    public class Harmful : ISpell
    {
        public SpellType SpellType { get; set; }
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
