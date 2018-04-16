using MvvmCross.Core.ViewModels;
using Redoubt.Core.ViewModels;

namespace Redoubt.Core
{
    public class CustomAppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null) =>
            ShowViewModel<MainMenuViewModel>();
    }
}
