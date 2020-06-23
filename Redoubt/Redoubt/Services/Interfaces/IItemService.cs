using Redoubt.Enums;
using Redoubt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redoubt.Services.Interfaces
{
    public interface IItemService
    {
        Item NewItem();
        Task<Item> NewItemAsync();
        Quality RandomQuality();
        Task<Quality> RandomQualityAsync();
        Rarity RandomRarity();
        Task<Rarity> RandomRarityAsync();
        Slot RandomSlot();
        Task<Slot> RandomSlotAsync();
        int Sum(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes, Attribute attribute);
        Task<int> SumAsync(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes, Attribute attribute);
        int Sum(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers, Modifier modifier);
        Task<int> SumAsync(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers, Modifier modifier);
        string GenerateName(Slot slot, IEnumerable<KeyValuePair<Attribute, int>> rawAttributes, IEnumerable<KeyValuePair<Modifier, int>> rawModifiers);
        Task<string> GenerateNameAsync(Slot slot, IEnumerable<KeyValuePair<Attribute, int>> rawAttributes, IEnumerable<KeyValuePair<Modifier, int>> rawModifiers);
        string GetAttributePrefix(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes);
        Task<string> GetAttributePrefixAsync(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes);
        string GetAttributeSuffix(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes);
        Task<string> GetAttributeSuffixAsync(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes);
        string GetModifierPrefix(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers);
        Task<string> GetModifierPrefixAsync(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers);
        string GetModifierSuffix(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers);
        Task<string> GetModifierSuffixAsync(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers);
        IEnumerable<KeyValuePair<Attribute, int>> CombineRawAttributes(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes);
        Task<IEnumerable<KeyValuePair<Attribute, int>>> CombineRawAttributesAsync(IEnumerable<KeyValuePair<Attribute, int>> rawAttributes);
        IEnumerable<KeyValuePair<Modifier, int>> CombineRawModifiers(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers);
        Task<IEnumerable<KeyValuePair<Modifier, int>>> CombineRawModifiersAsync(IEnumerable<KeyValuePair<Modifier, int>> rawModifiers);
        IEnumerable<KeyValuePair<Attribute, int>> GenerateRawAttributes(Rarity rarity);
        Task<IEnumerable<KeyValuePair<Attribute, int>>> GenerateRawAttributesAsync(Rarity rarity);
        IEnumerable<KeyValuePair<Modifier, int>> GenerateRawModifiers(Quality quality);
        Task<IEnumerable<KeyValuePair<Modifier, int>>> GenerateRawModifiersAsync(Quality quality);
    }
}
