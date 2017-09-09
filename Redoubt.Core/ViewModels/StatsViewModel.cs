using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class StatsViewModel : MvxViewModel
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
