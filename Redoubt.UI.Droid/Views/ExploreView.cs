using Android.App;
using MvvmCross.Droid.Views;

namespace Redoubt.UI.Droid.Views
{
    [Activity(Label = "ExploreView")]
    public class ExploreView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Explore);
        }
    }
}