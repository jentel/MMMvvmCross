
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
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

            var bottomNavView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
			bottomNavView.NavigationItemSelected += (sender, e) =>
			{
				switch (e.Item.ItemId)
				{
					case Resource.Id.menu_cut:
						Toast.MakeText(this, "meow", ToastLength.Short).Show();

						//Android.Support.V4.App.FragmentTransaction fragmentTransaction = this.SupportFragmentManager.BeginTransaction();
						//MainMenuView browseFragment = new MainMenuView();
						//fragmentTransaction.Replace(Resource.Id.content_frame, (Android.Support.V4.App.Fragment)browseFragment, "main_menu");
						//fragmentTransaction.Commit();

						//var fragment = (MainMenuView)Activator.CreateInstance(typeof(MainMenuView));
						//                  fragment.ViewModel = new MainMenuViewModel();
						//SupportFragmentManager.BeginTransaction()
						//                      .Replace(Resource.Id.content_frame, fragment,"main_menu")
						//.Commit();



						break;

					case Resource.Id.menu_copy:
						Toast.MakeText(this, "meow, meow", ToastLength.Short).Show();
						//Android.Support.V4.App.FragmentTransaction fragmentTransaction2 = this.SupportFragmentManager.BeginTransaction();
						//AboutFragment aboutFragment = new AboutFragment();
						//fragmentTransaction2.Replace(Resource.Id.main_container, aboutFragment);
						//fragmentTransaction2.Commit();

						break;
				}
			};
        }
    }
}
