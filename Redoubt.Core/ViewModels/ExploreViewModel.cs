using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class ExploreViewModel : MvxViewModel
    {
        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }
    }
}
