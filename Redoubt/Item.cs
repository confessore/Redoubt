using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Redoubt
{
    public class Item
    {
        Random Random { get; set; }
        public Item()
        {
            Random = new Random(DateTime.UtcNow.Millisecond * Thread.CurrentThread.ManagedThreadId);
            Quality = (Quality)Random.Next(Enum.GetNames(typeof(Quality)).Length);
            Rarity = (Rarity)Random.Next(Enum.GetNames(typeof(Quality)).Length);
            Slot = (Slot)Random.Next(Enum.GetNames(typeof(Quality)).Length);
            RawAttributes = GenerateRawAttributes();
            RawModifiers = GenerateRawModifiers();
            Attributes = CombineRawAttributes();
            Modifiers = CombineRawModifiers();
            Name = GenerateName();
            Strength = AttributeSum(Attribute.STRENGTH);
            Dexterity = AttributeSum(Attribute.DEXTERITY);
            Intellect = AttributeSum(Attribute.INTELLECT);
            Vitality = AttributeSum(Attribute.VITALITY);
            Attack = ModifierSum(Modifier.ATTACK);
            Will = ModifierSum(Modifier.WILL);
            Hit = ModifierSum(Modifier.HIT);
            Crit = ModifierSum(Modifier.CRIT);
            Avoid = ModifierSum(Modifier.AVOID);
            Mitigate = ModifierSum(Modifier.MITIGATE);
        }

        public Item(Quality quality, Rarity rarity, Slot slot)
        {
            Quality = quality;
            Rarity = rarity;
            Slot = slot;
            RawAttributes = GenerateRawAttributes();
            RawModifiers = GenerateRawModifiers();
            Attributes = CombineRawAttributes();
            Modifiers = CombineRawModifiers();
            Name = GenerateName();
            Strength = AttributeSum(Attribute.STRENGTH);
            Dexterity = AttributeSum(Attribute.DEXTERITY);
            Intellect = AttributeSum(Attribute.INTELLECT);
            Vitality = AttributeSum(Attribute.VITALITY);
            Attack = ModifierSum(Modifier.ATTACK);
            Will = ModifierSum(Modifier.WILL);
            Hit = ModifierSum(Modifier.HIT);
            Crit = ModifierSum(Modifier.CRIT);
            Avoid = ModifierSum(Modifier.AVOID);
            Mitigate = ModifierSum(Modifier.MITIGATE);
        }

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
        public List<KeyValuePair<Attribute, int>> RawAttributes { get; set; }
        public List<KeyValuePair<Modifier, int>> RawModifiers { get; set; }
        public List<KeyValuePair<Attribute, int>> Attributes { get; set; }
        public List<KeyValuePair<Modifier, int>> Modifiers { get; set; }

        int AttributeSum(Attribute attribute)
        {
            var tmp = RawAttributes
                .GroupBy(x => x.Key);
            var ret = tmp.Where(x => x.Key == attribute).Select(x => x.Sum(y => y.Value));
            return ret.FirstOrDefault();
        }

        int ModifierSum(Modifier modifier)
        {
            var tmp = RawModifiers
                .GroupBy(x => x.Key);
            var ret = tmp.Where(x => x.Key == modifier).Select(x => x.Sum(y => y.Value));
            return ret.FirstOrDefault();
        }

        string GenerateName()
        {
            var attributePrefix = GetAttributePrefix();
            var modifierPrefix = GetModifierPrefix();
            var modifierSuffix = GetModifierSuffix();
            var attributeSuffix = GetAttributeSuffix();
            var s = GetAttributePrefix() != string.Empty ? $"{GetAttributePrefix()} " : string.Empty;
            s = GetAttributeSuffix() != string.Empty ? s + $"{GetAttributeSuffix()} " : s;
            s = s + $"{Slot}";
            if (GetModifierSuffix() != string.Empty || GetModifierPrefix() != string.Empty)
                s = s + " OF ";
            s = GetModifierPrefix() != string.Empty ? s + $"{GetModifierPrefix()} " : s;
            s = GetModifierSuffix() != string.Empty ? s + $"{GetModifierSuffix()}" : s;
            return s;
        }

        string GetAttributePrefix()
        {
            var tmp = RawAttributes
                .GroupBy(x => x.Key).OrderByDescending(x => x.Sum(y => y.Value)).ToList();
            var attribute = new KeyValuePair<Attribute, int>().Key;
            if (tmp.Count > 0)
                attribute = tmp[0].FirstOrDefault().Key;
            else
                return string.Empty;
            switch (attribute)
            {
                case Attribute.STRENGTH:
                    return AttributePrefix.BRUTAL.ToString();
                case Attribute.DEXTERITY:
                    return AttributePrefix.CLEVER.ToString();
                case Attribute.INTELLECT:
                    return AttributePrefix.LORDLY.ToString();
                case Attribute.VITALITY:
                    return AttributePrefix.DURABLE.ToString();
            }
            return string.Empty;
        }

        string GetAttributeSuffix()
        {
            var tmp = RawAttributes
                .GroupBy(x => x.Key).OrderByDescending(x => x.Sum(y => y.Value)).ToList();
            var modifier = new KeyValuePair<Attribute, int>().Key;
            if (tmp.Count > 1)
                modifier = tmp[1].FirstOrDefault().Key;
            else
                return string.Empty;
            switch (modifier)
            {
                case Attribute.STRENGTH:
                    return AttributeSuffix.BARBED.ToString();
                case Attribute.DEXTERITY:
                    return AttributeSuffix.FEATHERLIGHT.ToString();
                case Attribute.INTELLECT:
                    return AttributeSuffix.BLESSED.ToString();
                case Attribute.VITALITY:
                    return AttributeSuffix.REINFORCED.ToString();
            }
            return string.Empty;
        }

        string GetModifierPrefix()
        {
            var tmp = RawModifiers
                .GroupBy(x => x.Key).OrderByDescending(x => x.Sum(y => y.Value)).ToList();
            var modifier = new KeyValuePair<Modifier, int>().Key;
            if (tmp.Count > 1)
                modifier = tmp[1].FirstOrDefault().Key;
            else
                return string.Empty;
            switch (modifier)
            {
                case Modifier.ATTACK:
                    return ModifierPrefix.COLOSSAL.ToString();
                case Modifier.WILL:
                    return ModifierPrefix.CALCULATED.ToString();
                case Modifier.HIT:
                    return ModifierPrefix.TRUTHFUL.ToString();
                case Modifier.CRIT:
                    return ModifierPrefix.DECEITFUL.ToString();
                case Modifier.AVOID:
                    return ModifierPrefix.AGILE.ToString();
                case Modifier.MITIGATE:
                    return ModifierPrefix.THICK.ToString();
            }
            return string.Empty;
        }

        string GetModifierSuffix()
        {
            var tmp = RawModifiers
                .GroupBy(x => x.Key).OrderByDescending(x => x.Sum(y => y.Value)).ToList();
            var modifier = new KeyValuePair<Modifier, int>().Key;
            if (tmp.Count > 0)
                modifier = tmp[0].FirstOrDefault().Key;
            else
                return string.Empty;
            switch (modifier)
            {
                case Modifier.ATTACK:
                    return ModifierSuffix.DEVASTATION.ToString();
                case Modifier.WILL:
                    return ModifierSuffix.CONCENTRATION.ToString();
                case Modifier.HIT:
                    return ModifierSuffix.ACCURACY.ToString();
                case Modifier.CRIT:
                    return ModifierSuffix.ADVANTAGE.ToString();
                case Modifier.AVOID:
                    return ModifierSuffix.ELUSIVENESS.ToString();
                case Modifier.MITIGATE:
                    return ModifierSuffix.IMMOVABILITY.ToString();
            }
            return string.Empty;
        }

        List<KeyValuePair<Attribute, int>> CombineRawAttributes()
        {
            var list = new List<KeyValuePair<Attribute, int>>();
            var tmp = RawAttributes
                .GroupBy(x => x.Key);
            var count = new int();
            foreach (var group in tmp)
            {
                count = 0;
                foreach (var pair in group)
                    count += pair.Value;
                list.Add(new KeyValuePair<Attribute, int>(group.Key, count));
            }
            return list;
        }

        List<KeyValuePair<Modifier, int>> CombineRawModifiers()
        {
            var list = new List<KeyValuePair<Modifier, int>>();
            var tmp = RawModifiers
                .GroupBy(x => x.Key);
            var count = new int();
            foreach (var group in tmp)
            {
                count = 0;
                foreach (var pair in group)
                    count += pair.Value;
                list.Add(new KeyValuePair<Modifier, int>(group.Key, count));
            }
            return list;
        }

        List<KeyValuePair<Attribute, int>> GenerateRawAttributes()
        {
            var tmp = new List<KeyValuePair<Attribute, int>>();
            for (int x = 0; x < (int)Rarity; x++)
                tmp.Add(new KeyValuePair<Attribute, int>((Attribute)Random.Next(0, Enum.GetNames(typeof(Attribute)).Length), new Random().Next(1, 10)));
            return tmp;
        }

        List<KeyValuePair<Modifier, int>> GenerateRawModifiers()
        {
            var tmp = new List<KeyValuePair<Modifier, int>>();
            for (int x = 0; x < (int)Quality; x++)
                tmp.Add(new KeyValuePair<Modifier, int>((Modifier)Random.Next(0, Enum.GetNames(typeof(Modifier)).Length), new Random().Next(1, 4)));
            return tmp;
        }
    }

    public enum Attribute
    {
        STRENGTH = 0,
        DEXTERITY,
        INTELLECT,
        VITALITY
    }

    public enum Slot
    {
        HEAD = 0,
        NECK,
        SHOULDERS,
        BACK,
        CHEST,
        WRISTS,
        HANDS,
        WAIST,
        LEGS,
        FEET,
        FINGER,
        POCKET,
        MAINHAND,
        OFFHAND
    }

    public enum Modifier
    {
        ATTACK = 0,
        WILL,
        HIT,
        CRIT,
        AVOID,
        MITIGATE
    }

    public enum Quality
    {
        BROKEN = 0,
        DAMAGED,
        LOW,
        NORMAL,
        SUPERIOR
    }

    public enum Rarity
    {
        COMMON = 0,
        UNCOMMON,
        RARE,
        UNIQUE,
        ARTIFACT
    }

    public enum AttributePrefix
    {
        BRUTAL = 0,
        CLEVER,
        LORDLY,
        DURABLE
    }

    public enum AttributeSuffix
    {
        BARBED = 0,
        FEATHERLIGHT,
        BLESSED,
        REINFORCED
    }

    public enum ModifierPrefix
    {
        COLOSSAL = 0,
        CALCULATED,
        TRUTHFUL,
        DECEITFUL,
        AGILE,
        THICK
    }

    public enum ModifierSuffix
    {
        DEVASTATION = 0,
        CONCENTRATION,
        ACCURACY,
        ADVANTAGE,
        ELUSIVENESS,
        IMMOVABILITY
    }
}
