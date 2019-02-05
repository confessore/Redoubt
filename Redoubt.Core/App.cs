using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace Redoubt.Core
{
    public class App : MvxApplication
    {
        public static Player Player { get; set; }

        public App()
        {
            var appStart = new CustomAppStart();
            Mvx.RegisterSingleton<IMvxAppStart>(appStart);
        }
    }
}
