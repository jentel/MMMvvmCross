using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using Collections.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Support.V7.Widget;

namespace Collections.Droid.Views
{
    //[Activity(Label = "Main Menu", ScreenOrientation = ScreenOrientation.Portrait, Icon = "@drawable/upload", Theme = "@style/AppTheme")]
    public class MainMenuView : MvxFragment<MainMenuViewModel>
    {
        //protected override void OnViewModelSet()
        //{
            //SetContentView(Resource.Layout.Page_MainMenuView);

            //var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            //bottomNavigation.NavigationItemSelected += (s, e) =>
            //{
            //    switch (e.Item.ItemId)
            //    {
            //        case Resource.Id.action_search:
            //            Toast.MakeText(this, "Action search Clicked", ToastLength.Short).Show();
            //            break;

            //        case Resource.Id.action_settings:
            //            Toast.MakeText(this, "Action settings Clicked", ToastLength.Short).Show();
            //            break;

            //        case Resource.Id.action_navigation:
            //            Toast.MakeText(this, "Action navigation Clicked", ToastLength.Short).Show();
            //            break;
            //    }
            //};
        //}

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.Page_MainMenuView, null);

            var bottomNavigation = view.FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            if(bottomNavigation != null)
            {
                var layoutManager = new LinearLayoutManager(Activity);
                bottomNavigation.SetLayoutManager(layoutManager);
            }
        }
    }
}

   //     protected override void OnCreate(Android.OS.Bundle savedInstanceState)
   //     {
   //         base.OnCreate(savedInstanceState);
			//SetContentView(Resource.Layout.Page_MainMenuView);

        //    var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
        //    bottomNavigation.NavigationItemSelected += (s, e) =>
        //    {
        //        switch (e.Item.ItemId)
        //        {
        //            case Resource.Id.action_search:
        //                Toast.MakeText(this, "Action search Clicked", ToastLength.Short).Show();
        //                break;

        //            case Resource.Id.action_settings:
        //                Toast.MakeText(this, "Action settings Clicked", ToastLength.Short).Show();
        //                break;

        //            case Resource.Id.action_navigation:
        //                Toast.MakeText(this, "Action navigation Clicked", ToastLength.Short).Show();
        //                break;
        //        }
        //    };
        //}
//    }
//}