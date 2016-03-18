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
using Android.Text.Method;

namespace MyMvxSimple.Droid.Views
{
    [Activity(Label = "Detail View")]
    public class HttpClientDetailView : MvxActivity
    {
        public HttpClientDetailView()
        {

        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HttpClientDetailViewLayout);
            //MultiLine text view support scroll
            var wtf = FindViewById<TextView>(Resource.Id.WTF);
            wtf.MovementMethod = new ScrollingMovementMethod();
        }
    }
}