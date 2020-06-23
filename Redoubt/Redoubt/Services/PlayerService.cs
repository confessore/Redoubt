using Newtonsoft.Json;
using Redoubt.Models;
using Redoubt.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Redoubt.Services
{
    public class PlayerService : IPlayerService
    {
        IItemService ItemService => DependencyService.Get<IItemService>();

        public Player NewPlayer(string name) =>
            NewPlayerAsync(name).Result;

        public async Task<Player> NewPlayerAsync(string name)
        {
            var player = new Player(name);
            for (int i = 0; i < 100; i++)
                player.Inventory.Add(await ItemService.NewItemAsync());
            return await Task.FromResult(player).ConfigureAwait(false);
        }

        public async Task SavePlayerAsync()
        {
            var json = JsonConvert.SerializeObject(App.Player);
            await File.WriteAllTextAsync(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/player", json);
        }

        public async Task LoadPlayerAsync()
        {
            var json = await File.ReadAllTextAsync(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/player");
            App.Player = JsonConvert.DeserializeObject<Player>(json);
        }
    }
}
