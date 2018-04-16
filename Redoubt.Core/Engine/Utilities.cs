using Newtonsoft.Json;
using Redoubt.Core.Engine.Objects.Databases;
using Redoubt.Core.Engine.Objects.Items;
using Redoubt.Core.Engine.Objects.Types;
using Redoubt.Core.Engine.Objects.Units;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Redoubt.Core.Engine
{
    public class Utilities
    {
        private ConsumableDatabase ConsumableDatabase { get; }
        private EquippableDatabase EquippableDatabase { get; }
        private Player Player { get; }

        public Utilities(ConsumableDatabase consumableDatabase, EquippableDatabase equippableDatabase, Player player)
        {
            ConsumableDatabase = consumableDatabase;
            EquippableDatabase = equippableDatabase;
            Player = player;
        }

        private string saveFileName = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "save.dat";
        private Dictionary<string, Player> save = new Dictionary<string, Player>();

        public async Task UpdateDictionary()
        {
            await Task.Run(() =>
            {
                save.Clear();
                save.Add(Player.Name, Player);
            });
        }

        public async Task SaveGame()
        {
            await Task.Run(() =>
            {
                using (StreamWriter file = File.CreateText(saveFileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, save.Values.ToArray());
                }
            });
        }

        public async Task NewGame(string name)
        {
            await Task.Run(async () =>
            {

                Player player = new Player
                {
                    UnitType = UnitType.Humanoid,
                    Name = name,
                    Minimum = 5,
                    Maximum = 10,
                    Hitpoints = 100,
                    Magicpoints = 50,
                    Armor = 0,
                    Strength = 15,
                    Dexterity = 10,
                    Stamina = 10,
                    Magic = 10,

                    Bag = new Dictionary<string, Consumable>()
                    {
                        { ConsumableDatabase.LesserHealthPotion.Name, ConsumableDatabase.LesserHealthPotion }
                    },

                    Inventory = new Dictionary<string, Equippable>()
                    {
                        { EquippableDatabase.ShortSword.Name, EquippableDatabase.ShortSword },
                    }
                };

                Player.UnitType = player.UnitType;
                Player.Name = player.Name;
                Player.Minimum = player.Minimum;
                Player.Maximum = player.Maximum;
                Player.Hitpoints = player.Hitpoints;
                Player.Magicpoints = player.Magicpoints;
                Player.Armor = player.Armor;
                Player.Strength = player.Strength;
                Player.Dexterity = player.Dexterity;
                Player.Stamina = player.Stamina;
                Player.Magic = player.Magic;
                Player.Bag = player.Bag;
                Player.Inventory = player.Inventory;

                await UpdateDictionary();
                await SaveGame();
            });
        }

        public async Task LoadGame()
        {
            await Task.Run(async () =>
            {
                using (StreamReader file = File.OpenText(saveFileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Player[] info = (Player[])serializer.Deserialize(file, typeof(Player[]));
                    save = info.ToDictionary((u) => u.Name, (u) => u);
                }

                Player player = new Player
                {
                    UnitType = save.Values.Select(x => x.UnitType).FirstOrDefault(),
                    Name = save.Values.Select(x => x.Name).FirstOrDefault(),
                    Minimum = save.Values.Select(x => x.Minimum).FirstOrDefault(),
                    Maximum = save.Values.Select(x => x.Maximum).FirstOrDefault(),
                    Hitpoints = save.Values.Select(x => x.Hitpoints).FirstOrDefault(),
                    Magicpoints = save.Values.Select(x => x.Magicpoints).FirstOrDefault(),
                    Armor = save.Values.Select(x => x.Armor).FirstOrDefault(),
                    Strength = save.Values.Select(x => x.Strength).FirstOrDefault(),
                    Dexterity = save.Values.Select(x => x.Dexterity).FirstOrDefault(),
                    Stamina = save.Values.Select(x => x.Stamina).FirstOrDefault(),
                    Magic = save.Values.Select(x => x.Magic).FirstOrDefault(),
                    Bag = new Dictionary<string, Consumable>(),
                    Inventory = new Dictionary<string, Equippable>()
                };

                foreach (var item in save.Values.SelectMany(x => x.Bag))
                    player.Bag.Add(item.Key, item.Value);

                foreach (var item in save.Values.SelectMany(x => x.Inventory))
                    player.Inventory.Add(item.Key, item.Value);

                Player.UnitType = player.UnitType;
                Player.Name = player.Name;
                Player.Minimum = player.Minimum;
                Player.Maximum = player.Maximum;
                Player.Hitpoints = player.Hitpoints;
                Player.Magicpoints = player.Magicpoints;
                Player.Armor = player.Armor;
                Player.Strength = player.Strength;
                Player.Dexterity = player.Dexterity;
                Player.Stamina = player.Stamina;
                Player.Magic = player.Magic;
                Player.Bag = player.Bag;
                Player.Inventory = player.Inventory;

                await UpdateDictionary();
                await SaveGame();
            });
        }

        public void DisplayStats()
        {
            Console.WriteLine(Player.UnitType);
            Console.WriteLine(Player.Name);
            Console.WriteLine(Player.Minimum);
            Console.WriteLine(Player.Maximum);
            Console.WriteLine(Player.Hitpoints);
            Console.WriteLine(Player.Magicpoints);
            Console.WriteLine(Player.Armor);
            Console.WriteLine(Player.Strength);
            Console.WriteLine(Player.Dexterity);
            Console.WriteLine(Player.Stamina);
            Console.WriteLine(Player.Magic);
            Console.WriteLine(Player.Bag.Values);
            Console.WriteLine(Player.Inventory.Values);
        }
    }
}
