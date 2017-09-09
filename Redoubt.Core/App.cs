using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Redoubt.Core.Services;

namespace Redoubt.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterType<IBillCalculator, BillCalculator>();
            var calcExample = Mvx.Resolve<IBillCalculator>();

            var appStart = new CustomAppStart();
            Mvx.RegisterSingleton<IMvxAppStart>(appStart);
        }
    }
}
