using Android.App;
using MvvmCross.Droid.Views;
using System;

namespace Redoubt.UI.Droid.Views
{
    [Activity(Label = "EquipmentView")]
    public class EquipmentView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Equipment);
        }

        protected override void OnDestroy()
        {
            if (base.ViewModel is IDisposable)
                (base.ViewModel as IDisposable).Dispose();
            base.OnDestroy();
        }
    }
}