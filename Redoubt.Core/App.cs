using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;

namespace Redoubt.Core
{
    public class App : MvxApplication
    {
        public static Player Player { get; set; }
        public static Random Random = new Random();

        public App()
        {
            var appStart = new CustomAppStart();
            Mvx.RegisterSingleton<IMvxAppStart>(appStart);
        }
    }
}
