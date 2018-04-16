using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Redoubt.Core.Engine.Modules;
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

        private static UtilityModule utilityModule;
        public static UtilityModule UtilityModule
        {
            get => utilityModule;
            set => utilityModule = value;
        }

        public App()
        {
            consumableDatabase = new ConsumableDatabase();
            equippableDatabase = new EquippableDatabase();
            player = new Player();
            utilityModule = new UtilityModule(ConsumableDatabase, EquippableDatabase, Player);

            var appStart = new CustomAppStart();
            Mvx.RegisterSingleton<IMvxAppStart>(appStart);
        }
    }
}
