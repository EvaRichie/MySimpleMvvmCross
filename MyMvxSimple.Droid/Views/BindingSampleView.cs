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
using Android.Views.InputMethods;
using MyMvxSimple.Droid.Fragments;

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
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            var tab = this.ActionBar.NewTab();
            tab.SetText("Tb1");
            tab.TabSelected += (obj, e) =>
            {
                e.FragmentTransaction.Replace(Resource.Id.FrameLayout, new Fragment1View());
            };
            this.ActionBar.AddTab(tab);
            tab = this.ActionBar.NewTab();
            tab.SetText("Tb2");
            tab.TabSelected += (obj, e) =>
            {
                e.FragmentTransaction.Replace(Resource.Id.FrameLayout, new Fragment2View());
            };
            this.ActionBar.AddTab(tab);
            var bindingRootLayout = FindViewById<LinearLayout>(Resource.Id.BindingViewRootLayout);
            bindingRootLayout.Touch += BindingRootLayout_Touch;
        }

        private void BindingRootLayout_Touch(object sender, View.TouchEventArgs e)
        {
            var imMgr = GetSystemService(Context.InputMethodService) as InputMethodManager;
            if (imMgr != null && CurrentFocus != null)
                imMgr.HideSoftInputFromWindow(CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}