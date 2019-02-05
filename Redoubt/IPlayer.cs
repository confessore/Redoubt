using System.Collections.Generic;

namespace Redoubt
{
    public interface IPlayer
    {
        string Name { get; set; }
        int Level { get; set; }
        int Strength { get; set; }
        int Dexterity { get; set; }
        int Intellect { get; set; }
        int Vitality { get; set; }
        int Attack { get; set; }
        int Will { get; set; }
        int Hit { get; set; }
        int Crit { get; set; }
        int Avoid { get; set; }
        int Mitigate { get; set; }
        List<Item> Inventory { get; set; }
        List<KeyValuePair<Slot, Item>> Equipment { get; set; }
        List<KeyValuePair<Attribute, int>> RawAttributes { get; set; }
        List<KeyValuePair<Modifier, int>> RawModifiers { get; set; }
        List<KeyValuePair<Attribute, int>> Attributes { get; set; }
        List<KeyValuePair<Modifier, int>> Modifiers { get; set; }
    }
}
