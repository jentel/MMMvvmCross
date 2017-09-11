
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
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Collections.Core.ViewModels;
using Collections.Core.ViewModels.Samples.SmallFixed;
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
    public class FirstActivity : MvxAppCompatActivity<FirstViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Page_First);

			var fragment = (MainMenuView)Activator.CreateInstance(typeof(MainMenuView));
			fragment.ViewModel = new MainMenuViewModel();
			SupportFragmentManager.BeginTransaction()
								  .Replace(Resource.Id.content_frame, fragment, "main_menu")
			                      .Commit();

            var bottomNavView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
			bottomNavView.NavigationItemSelected += (sender, e) =>
			{
				switch (e.Item.ItemId)
				{
					case Resource.Id.menu_cut:
                        SupportFragmentManager.BeginTransaction()
                                              .Replace(Resource.Id.content_frame, fragment,"main_menu")
                                              .Commit();


						break;

					case Resource.Id.menu_copy:
						Toast.MakeText(this, "meow, meow", ToastLength.Short).Show();
						
                        var fixedFrag = (SmallFixedView)Activator.CreateInstance(typeof(SmallFixedView));
                        fixedFrag.ViewModel = new SmallFixedViewModel(ViewModel.Service);
						SupportFragmentManager.BeginTransaction()
											  .Replace(Resource.Id.content_frame, fixedFrag, "small_fixed")
						                      .Commit();

						break;
				}
			};
        }
    }
}
