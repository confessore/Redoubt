using Android.App;
using MvvmCross.Droid.Views;

namespace Redoubt.UI.Droid.Views
{
    [Activity(Label = "HomeView")]
    public class HomeView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Home);
        }
    }
}