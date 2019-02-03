using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Redoubt.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var item = new Item();
                Console.Clear();
                Console.WriteLine(item.Quality);
                Console.WriteLine(item.Rarity);
                Console.WriteLine(item.Slot);
                Console.WriteLine(item.Name);
                foreach (var stat in item.Attributes)
                    Console.WriteLine($"{stat.Key}: {stat.Value}");
                foreach (var mod in item.Modifiers)
                    Console.WriteLine($"{mod.Key}: {mod.Value}");
                var json = JsonConvert.SerializeObject(item, Formatting.Indented);
                File.WriteAllText(Assembly.GetExecutingAssembly().ExtJumpUp(1) + "/Item", json);
                Console.Read();
            }
        }
    }
}
