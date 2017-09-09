using Android.App;
using MvvmCross.Droid.Views;

namespace Redoubt.UI.Droid.Views
{
    [Activity(Label = "StatsView")]
    public class StatsView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Stats);
        }
    }
}