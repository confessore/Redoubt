using Android.App;
using MvvmCross.Droid.Views;

namespace Redoubt.UI.Droid.Views
{
    [Activity(Label = "InventoryView")]
    public class InventoryView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Inventory);
        }
    }
}