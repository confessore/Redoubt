using Android.App;
using MvvmCross.Droid.Views;

namespace Redoubt.UI.Droid.Views
{
    [Activity(Label = "ShopView")]
    public class ShopView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Shop);
        }
    }
}