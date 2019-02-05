using System.Collections.Generic;

namespace Redoubt
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public int Level { get; set; }
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
        public List<Item> Inventory { get; set; }
        public List<KeyValuePair<Slot, Item>> Equipment { get; set; }
        public List<KeyValuePair<Attribute, int>> RawAttributes { get; set; }
        public List<KeyValuePair<Modifier, int>> RawModifiers { get; set; }
        public List<KeyValuePair<Attribute, int>> Attributes { get; set; }
        public List<KeyValuePair<Modifier, int>> Modifiers { get; set; }
    }
}
