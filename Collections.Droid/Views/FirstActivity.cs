
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Collections.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;

namespace Collections.Droid.Views
{
	[Activity(
        Label = "Main Activity",
		Theme = "@style/AppTheme",
		LaunchMode = LaunchMode.SingleTop,
		Name = "collections.droid.views.FirstActivity"
     )]
    public class FirstActivity : MvxCachingFragmentCompatActivity<FirstViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Page_First);
        }
    }
}
