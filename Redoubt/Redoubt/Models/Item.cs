using Newtonsoft.Json;
using Redoubt.Enums;
using Redoubt.Services.Interfaces;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Attribute = Redoubt.Enums.Attribute;

namespace Redoubt.Models
{
    public class Item
    {
        IItemService ItemService => DependencyService.Get<IItemService>();

        public Item()
        {
            Guid = Guid.NewGuid();
            Quality = ItemService.RandomQuality();
            Rarity = ItemService.RandomRarity();
            Slot = ItemService.RandomSlot();
            RawAttributes = ItemService.GenerateRawAttributes(Rarity);
            RawModifiers = ItemService.GenerateRawModifiers(Quality);
            Attributes = ItemService.CombineRawAttributes(RawAttributes);
            Modifiers = ItemService.CombineRawModifiers(RawModifiers);
            Name = ItemService.GenerateName(Slot, RawAttributes, RawModifiers);
            Strength = ItemService.Sum(RawAttributes, Attribute.STRENGTH);
            Dexterity = ItemService.Sum(RawAttributes, Attribute.DEXTERITY);
            Intellect = ItemService.Sum(RawAttributes, Attribute.INTELLECT);
            Vitality = ItemService.Sum(RawAttributes, Attribute.VITALITY);
            Attack = ItemService.Sum(RawModifiers, Modifier.ATTACK);
            Will = ItemService.Sum(RawModifiers, Modifier.WILL);
            Hit = ItemService.Sum(RawModifiers, Modifier.HIT);
            Crit = ItemService.Sum(RawModifiers, Modifier.CRIT);
            Avoid = ItemService.Sum(RawModifiers, Modifier.AVOID);
            Mitigate = ItemService.Sum(RawModifiers, Modifier.MITIGATE);
        }

        [JsonConstructor]
        public Item(Guid guid, Quality quality, Rarity rarity, Slot slot,
            IEnumerable<KeyValuePair<Attribute, int>> rawAttributes, IEnumerable<KeyValuePair<Modifier, int>> rawModifiers)
        {
            Guid = guid;
            Quality = quality;
            Rarity = rarity;
            Slot = slot;
            RawAttributes = rawAttributes;
            RawModifiers = rawModifiers;
            Attributes = ItemService.CombineRawAttributes(RawAttributes);
            Modifiers = ItemService.CombineRawModifiers(RawModifiers);
            Name = ItemService.GenerateName(Slot, RawAttributes, RawModifiers);
            Strength = ItemService.Sum(RawAttributes, Attribute.STRENGTH);
            Dexterity = ItemService.Sum(RawAttributes, Attribute.DEXTERITY);
            Intellect = ItemService.Sum(RawAttributes, Attribute.INTELLECT);
            Vitality = ItemService.Sum(RawAttributes, Attribute.VITALITY);
            Attack = ItemService.Sum(RawModifiers, Modifier.ATTACK);
            Will = ItemService.Sum(RawModifiers, Modifier.WILL);
            Hit = ItemService.Sum(RawModifiers, Modifier.HIT);
            Crit = ItemService.Sum(RawModifiers, Modifier.CRIT);
            Avoid = ItemService.Sum(RawModifiers, Modifier.AVOID);
            Mitigate = ItemService.Sum(RawModifiers, Modifier.MITIGATE);
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Quality Quality { get; set; }
        public Rarity Rarity { get; set; }
        public Slot Slot { get; set; }
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
        public IEnumerable<KeyValuePair<Attribute, int>> RawAttributes { get; set; }
        public IEnumerable<KeyValuePair<Modifier, int>> RawModifiers { get; set; }
        public IEnumerable<KeyValuePair<Attribute, int>> Attributes { get; set; }
        public IEnumerable<KeyValuePair<Modifier, int>> Modifiers { get; set; }
    }
}
