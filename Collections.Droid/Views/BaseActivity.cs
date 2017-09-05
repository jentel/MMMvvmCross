using System;
using Android.App;
using Android.Content.PM;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Widget;
using Collections.Core;
using Collections.Core.ViewModels;
using Collections.Droid.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;

namespace Collections.Droid
{
	[Activity(Label = "Main Menu", ScreenOrientation = ScreenOrientation.Portrait, Icon = "@drawable/upload", Theme = "@style/AppTheme")]
    public class BaseActivity : MvxActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            //ActivityHolder.CurrentActivity = this;
        }

		protected override void OnViewModelSet()
		{
            SetContentView(Resource.Layout.Page_Base);

			//var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
			//bottomNavigation.NavigationItemSelected += (s, e) =>
			//{
				//switch (e.Item.ItemId)
				//{
				//	case Resource.Id.action_search:
				//		Toast.MakeText(this, "Action search Clicked", ToastLength.Short).Show();
				//		break;

				//	case Resource.Id.action_settings:
				//		Toast.MakeText(this, "Action settings Clicked", ToastLength.Short).Show();
				//		break;

				//	case Resource.Id.action_navigation:
				//		Toast.MakeText(this, "Action navigation Clicked", ToastLength.Short).Show();
				//		break;
				//}

                //LoadView(e.Item.ItemId);
			//};

            //this.CreateBinding(FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation)).To((BaseViewModel vm) => vm.LoadViewModel).Apply();

            //LoadView(Resource.Id.home);

            this.CreateBinding(FindViewById<Button>(Resource.Id.action_search)).To((BaseViewModel vm) => vm.LoadViewModel).Apply();
		}

   //     private void LoadView(int id)
   //     {
			//Android.Support.V4.App.Fragment fragment = null;
			//switch (id)
			//{
			//	case 0:
   //                 fragment = MainMenuView.;
			//		break;
			//	case Resource.Id.menu_audio:
			//		fragment = Fragment2.NewInstance();
			//		break;
			//	case Resource.Id.menu_video:
			//		fragment = Fragment3.NewInstance();
			//		break;
			//}

			//if (fragment == null)
			//	return;

			//FragmentManager.BeginTransaction()
				//.Replace(Resource.Id.content_frame, fragment)
				//.Commit();


        //}
    }
}
