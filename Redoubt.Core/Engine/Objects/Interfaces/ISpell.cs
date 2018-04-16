using Redoubt.Core.Engine.Objects.Interfaces.Types;

namespace Redoubt.Core.Engine.Objects.Interfaces
{
    public interface ISpell
    {
        SpellType SpellType { get; set; }
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
    }
}
