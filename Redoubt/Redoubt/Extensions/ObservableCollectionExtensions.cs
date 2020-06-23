using Redoubt.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Redoubt.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<Item> AdditiveOrderBySlot(this ObservableCollection<Item> collection, params Item[] inputs)
        {
            foreach (var input in inputs)
                collection.Add(input);
            return new ObservableCollection<Item>(collection.OrderBy(x => x.Slot));
        }

        public static ObservableCollection<Item> OrderBySlot(this ObservableCollection<Item> collection) =>
            new ObservableCollection<Item>(collection.OrderBy(x => x.Slot));
    }
}
