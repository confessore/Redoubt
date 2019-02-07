using System.Linq;

namespace Redoubt.Core.Statics
{
    public class Stats
    {
        public int Strength = App.Player.Strength + App.Player.Equipment.Sum(x => x.Strength);
        public int Dexterity = App.Player.Dexterity + App.Player.Equipment.Sum(x => x.Dexterity);
        public int Intellect = App.Player.Intellect + App.Player.Equipment.Sum(x => x.Intellect);
        public int Vitality = App.Player.Vitality + App.Player.Equipment.Sum(x => x.Vitality);
        public int Attack = App.Player.Attack + App.Player.Equipment.Sum(x => x.Attack);
        public int Will = App.Player.Will + App.Player.Equipment.Sum(x => x.Will);
        public int Hit = App.Player.Hit + App.Player.Equipment.Sum(x => x.Hit);
        public int Crit = App.Player.Crit + App.Player.Equipment.Sum(x => x.Crit);
        public int Avoid = App.Player.Avoid + App.Player.Equipment.Sum(x => x.Avoid);
        public int Mitigate = App.Player.Mitigate + App.Player.Equipment.Sum(x => x.Mitigate);
    }
}
