using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MyMvxSimple.Core.ViewModels;
using MvvmCross.Droid.FullFragging.Attributes;

namespace MyMvxSimple.Droid.Fragments
{
    //[MvxFragment(typeof(BindingSampleViewModel),Resource.Id.con)]
    public class Fragment1View : BaseFragment<BindingSampleViewModel>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            base.OnCreateView(inflater, container, savedInstanceState);
            var result = inflater.Inflate(Resource.Layout.Fragment1Layout, container, false);
            return result;
        }
    }
}