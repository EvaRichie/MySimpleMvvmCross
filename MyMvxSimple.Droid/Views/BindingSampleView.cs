using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace MyMvxSimple.Droid.Views
{
    [Activity(Label = "Bindin sample view")]
    public class BindingSampleView : MvxActivity
    {
        public BindingSampleView()
        {
        }

        public BindingSampleView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.BindingSampleViewLayout);
        }
    }
}