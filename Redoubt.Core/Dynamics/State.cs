using Newtonsoft.Json;
using System;
using System.IO;

namespace Redoubt.Core.Dynamics
{
    public class State
    {
        public void Save()
        {
            var json = JsonConvert.SerializeObject(App.Player);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/player", json);
        }

        public void Load()
        {
            var txt = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/player");
            App.Player = JsonConvert.DeserializeObject<Player>(txt);
        }
    }
}
