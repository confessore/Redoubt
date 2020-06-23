using Redoubt.Enums;
using Redoubt.Models;
using Redoubt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attribute = Redoubt.Enums.Attribute;

namespace Redoubt.Services
{
    public class ItemService : IItemService
    {
        Random Random { get; }

        public ItemService()
        {
            Random = new Random();
        }

        public Item NewItem() =>
            NewItemAsync().Result;

        public async Task<Item> NewItemAsync() =>
            await Task.FromResult(new Item()).ConfigureAwait(false);

        public Quality RandomQuality() =>
            RandomQualityAsync().Result;

        public async Task<Quality> RandomQualityAsync() =>
            await Task.FromResult((Quality)Random.Next(Enum.GetNames(typeof(Quality)).Length)).ConfigureAwait(false);

        public Rarity RandomRarity() =>
            RandomRarityAsync().Result;

        public async Task<Rarity> RandomRarityAsync() =>
            await Task.FromResult((Rarity)Random.Next(Enum.GetNames(typeof(Rarity)).Length)).ConfigureAwait(false);

        public Slot RandomSlot() =>
            RandomSlotAsync().Result;

        public async Task<Slot> RandomSlotAsync() =>
            await Task.FromResult((Slot)Random.Next(Enum.GetNames(typeof(Slot)).Length)).ConfigureAwait(false);

        public int Sum(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes, Attribute attribute) =>
            SumAsync(rawAttributes, attribute).Result;

        public async Task<int> SumAsync(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes, Attribute attribute)
        {
            var tmp = rawAttributes.GroupBy(x => x.Key);
            var ret = tmp.Where(x => x.Key == attribute).Select(x => x.Sum(y => y.Value));
            return await Task.FromResult(ret.FirstOrDefault()).ConfigureAwait(false);
        }

        public int Sum(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers, Modifier modifier) =>
            SumAsync(rawModifiers, modifier).Result;

        public async Task<int> SumAsync(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers, Modifier modifier)
        {
            var tmp = rawModifiers.GroupBy(x => x.Key);
            var ret = tmp.Where(x => x.Key == modifier).Select(x => x.Sum(y => y.Value));
            return await Task.FromResult(ret.FirstOrDefault()).ConfigureAwait(false);
        }

        public string GenerateName(Slot slot, IEnumerable<KeyValuePair<Attribute, int>> rawAttributes, IEnumerable<KeyValuePair<Modifier, int>> rawModifiers) =>
            GenerateNameAsync(slot, rawAttributes, rawModifiers).Result;

        public async Task<string> GenerateNameAsync(Slot slot, IEnumerable<KeyValuePair<Attribute, int>> rawAttributes, IEnumerable<KeyValuePair<Modifier, int>> rawModifiers)
        {
            var s = await GetAttributePrefixAsync(rawAttributes) != string.Empty ? $"{await GetAttributePrefixAsync(rawAttributes)} " : string.Empty;
            s = await GetAttributeSuffixAsync(rawAttributes) != string.Empty ? s + $"{await GetAttributeSuffixAsync(rawAttributes)} " : s;
            s = s + $"{slot}";
            if (await GetModifierSuffixAsync(rawModifiers) != string.Empty || await GetModifierPrefixAsync(rawModifiers) != string.Empty)
                s = s + " OF ";
            s = await GetModifierPrefixAsync(rawModifiers) != string.Empty ? s + $"{await GetModifierPrefixAsync(rawModifiers)} " : s;
            s = await GetModifierSuffixAsync(rawModifiers) != string.Empty ? s + $"{await GetModifierSuffixAsync(rawModifiers)}" : s;
            return s;
        }

        public string GetAttributePrefix(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes) =>
            GetAttributePrefixAsync(rawAttributes).Result;

        public async Task<string> GetAttributePrefixAsync(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes)
        {
            var tmp = rawAttributes.GroupBy(x => x.Key).OrderByDescending(x => x.Sum(y => y.Value)).ToList();
            var attribute = new KeyValuePair<Attribute, int>().Key;
            if (tmp.Count > 0)
                attribute = tmp[0].FirstOrDefault().Key;
            else
                return await Task.FromResult(string.Empty).ConfigureAwait(false);
            return await Task.FromResult(Enum.GetName(typeof(AttributePrefix), (int)attribute)).ConfigureAwait(false);
        }

        public string GetAttributeSuffix(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes) =>
            GetAttributeSuffixAsync(rawAttributes).Result;

        public async Task<string> GetAttributeSuffixAsync(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes)
        {
            var tmp = rawAttributes.GroupBy(x => x.Key).OrderByDescending(x => x.Sum(y => y.Value)).ToList();
            var attribute = new KeyValuePair<Attribute, int>().Key;
            if (tmp.Count > 1)
                attribute = tmp[1].FirstOrDefault().Key;
            else
                return await Task.FromResult(string.Empty).ConfigureAwait(false);
            return await Task.FromResult(Enum.GetName(typeof(AttributeSuffix), (int)attribute)).ConfigureAwait(false);
        }

        public string GetModifierPrefix(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers) =>
            GetModifierPrefixAsync(rawModifiers).Result;

        public async Task<string> GetModifierPrefixAsync(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers)
        {
            var tmp = rawModifiers.GroupBy(x => x.Key).OrderByDescending(x => x.Sum(y => y.Value)).ToList();
            var modifier = new KeyValuePair<Modifier, int>().Key;
            if (tmp.Count > 1)
                modifier = tmp[1].FirstOrDefault().Key;
            else
                return await Task.FromResult(string.Empty).ConfigureAwait(false);
            return await Task.FromResult(Enum.GetName(typeof(ModifierPrefix), (int)modifier)).ConfigureAwait(false);
        }

        public string GetModifierSuffix(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers) =>
            GetModifierSuffixAsync(rawModifiers).Result;

        public async Task<string> GetModifierSuffixAsync(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers)
        {
            var tmp = rawModifiers.GroupBy(x => x.Key).OrderByDescending(x => x.Sum(y => y.Value)).ToList();
            var modifier = new KeyValuePair<Modifier, int>().Key;
            if (tmp.Count > 0)
                modifier = tmp[0].FirstOrDefault().Key;
            else
                return await Task.FromResult(string.Empty).ConfigureAwait(false);
            return await Task.FromResult(Enum.GetName(typeof(ModifierSuffix), (int)modifier)).ConfigureAwait(false);
        }

        public IEnumerable<KeyValuePair<Attribute, int>> CombineRawAttributes(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes) =>
            CombineRawAttributesAsync(rawAttributes).Result;

        public async Task<IEnumerable<KeyValuePair<Attribute, int>>> CombineRawAttributesAsync(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes)
        {
            var list = new List<KeyValuePair<Attribute, int>>();
            var tmp = rawAttributes.GroupBy(x => x.Key);
            var count = new int();
            foreach (var group in tmp)
            {
                count = 0;
                foreach (var pair in group)
                    count += pair.Value;
                list.Add(new KeyValuePair<Attribute, int>(group.Key, count));
            }
            return await Task.FromResult<IEnumerable<KeyValuePair<Attribute, int>>>(list).ConfigureAwait(false);
        }

        public IEnumerable<KeyValuePair<Modifier, int>> CombineRawModifiers(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers) =>
            CombineRawModifiersAsync(rawModifiers).Result;

        public async Task<IEnumerable<KeyValuePair<Modifier, int>>> CombineRawModifiersAsync(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers)
        {
            var list = new List<KeyValuePair<Modifier, int>>();
            var tmp = rawModifiers.GroupBy(x => x.Key);
            var count = new int();
            foreach (var group in tmp)
            {
                count = 0;
                foreach (var pair in group)
                    count += pair.Value;
                list.Add(new KeyValuePair<Modifier, int>(group.Key, count));
            }
            return await Task.FromResult<IEnumerable<KeyValuePair<Modifier, int>>>(list).ConfigureAwait(false);
        }

        public IEnumerable<KeyValuePair<Attribute, int>> GenerateRawAttributes(Rarity rarity) =>
            GenerateRawAttributesAsync(rarity).Result;

        public async Task<IEnumerable<KeyValuePair<Attribute, int>>> GenerateRawAttributesAsync(Rarity rarity)
        {
            var tmp = new List<KeyValuePair<Attribute, int>>();
            for (int x = 0; x < (int)rarity; x++)
                tmp.Add(new KeyValuePair<Attribute, int>((Attribute)Random.Next(0, Enum.GetNames(typeof(Attribute)).Length), Random.Next(1, 10)));
            return await Task.FromResult<IEnumerable<KeyValuePair<Attribute, int>>>(tmp).ConfigureAwait(false);
        }

        public IEnumerable<KeyValuePair<Modifier, int>> GenerateRawModifiers(Quality quality) =>
            GenerateRawModifiersAsync(quality).Result;

        public async Task<IEnumerable<KeyValuePair<Modifier, int>>> GenerateRawModifiersAsync(Quality quality)
        {
            var tmp = new List<KeyValuePair<Modifier, int>>();
            for (int x = 0; x < (int)quality; x++)
                tmp.Add(new KeyValuePair<Modifier, int>((Modifier)Random.Next(0, Enum.GetNames(typeof(Modifier)).Length), Random.Next(1, 5)));
            return await Task.FromResult<IEnumerable<KeyValuePair<Modifier, int>>>(tmp).ConfigureAwait(false);
        }
    }
}
