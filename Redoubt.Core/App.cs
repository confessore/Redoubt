using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Redoubt.Core.Engine;
using Redoubt.Core.Engine.Objects.Databases;
using Redoubt.Core.Engine.Objects.Units;

namespace Redoubt.Core
{
    public class App : MvxApplication
    {
        private static ConsumableDatabase consumableDatabase;
        public static ConsumableDatabase ConsumableDatabase
        {
            get => consumableDatabase;
            set => consumableDatabase = value;
        }

        private static EquippableDatabase equippableDatabase;
        public static EquippableDatabase EquippableDatabase
        {
            get => equippableDatabase;
            set => equippableDatabase = value;
        }

        private static Player player;
        public static Player Player
        {
            get => player;
            set => player = value;
        }

        private static Utilities utilities;
        public static Utilities Utilities
        {
            get => utilities;
            set => utilities = value;
        }

        public App()
        {
            consumableDatabase = new ConsumableDatabase();
            equippableDatabase = new EquippableDatabase();
            player = new Player();
            utilities = new Utilities(ConsumableDatabase, EquippableDatabase, Player);

            var appStart = new CustomAppStart();
            Mvx.RegisterSingleton<IMvxAppStart>(appStart);
        }
    }
}
