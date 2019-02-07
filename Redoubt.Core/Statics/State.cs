using Newtonsoft.Json;
using System;
using System.IO;

namespace Redoubt.Core.Statics
{
    public class State
    {
        static Lazy<State> instance = new Lazy<State>(() => new State());
        public static State Instance = instance.Value;

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
