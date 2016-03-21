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
    [Activity(Label = "Splash Screen", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreenView : MvxSplashScreenActivity
    {
        public SplashScreenView() : base(Resource.Layout.SplashScreenLayout)
        {
        }
    }
}