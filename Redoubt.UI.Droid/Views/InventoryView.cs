﻿using Android.App;
using MvvmCross.Droid.Views;
using System;

namespace Redoubt.UI.Droid.Views
{
    [Activity(Label = "InventoryView")]
    public class InventoryView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Inventory);
        }

        protected override void OnDestroy()
        {
            if (base.ViewModel is IDisposable)
                (base.ViewModel as IDisposable).Dispose();
            base.OnDestroy();
        }
    }
}
