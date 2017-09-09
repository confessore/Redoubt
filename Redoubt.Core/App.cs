using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace Redoubt.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            var appStart = new CustomAppStart();
            Mvx.RegisterSingleton<IMvxAppStart>(appStart);
        }
    }
}
