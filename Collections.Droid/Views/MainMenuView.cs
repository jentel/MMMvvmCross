using System;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Widget;
using BottomNavigationBar;
using BottomNavigationBar.Listeners;
using Collections.Droid.Plumbing.BottomNavBar;
using MvvmCross.Droid.Views;

namespace Collections.Droid.Views
{
    [Activity(Label = "Main Menu", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainMenuView : MvxActivity, IOnTabClickListener
    {
        private BottomBar _bottomBar;

		BottomBarBadge _badge0;
		BottomBarBadge _badge1;
		BottomBarBadge _badge2;

        public void OnTabReSelected(int position)
        {
            Toast.MakeText(ApplicationContext, "Tab reselected!", ToastLength.Short).Show();
        }

        public void OnTabSelected(int position)
        {
            Toast.MakeText(ApplicationContext, "Tab selected!", ToastLength.Short).Show();
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_MainMenuView);
        }

        public override void OnCreate(Android.OS.Bundle savedInstanceState, Android.OS.PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);

            _bottomBar = BottomBar.AttachShy(FindViewById<CoordinatorLayout>(Resource.Id.myCoordinator), FindViewById(Resource.Id.myScrollingContent), savedInstanceState);

            _bottomBar.UseFixedMode();
            _bottomBar.UseDarkThemeWithAlpha();

			_bottomBar.SetItems(new[] {
                new BottomBarTab(Resource.Drawable.Icon, "Recents"),
                new BottomBarTab(Resource.Drawable.Icon, "Favorites"),
                new BottomBarTab(Resource.Drawable.Icon, "Nearby")
			});
			_badge0 = _bottomBar.MakeBadgeForTabAt(0, Color.Green, 100);
			_badge0.AutoShowAfterUnSelection = true;

			_badge1 = _bottomBar.MakeBadgeForTabAt(1, Color.Green, 100);
			_badge1.AutoShowAfterUnSelection = true;
			_badge1.Position = BottomNavigationBar.Enums.BadgePosition.Left;

			_badge2 = new CustomBottomBarBadge(this, 2, Color.Green);
			_badge2.Count = 100;
			_bottomBar.MakeBadgeForTab(_badge2);

			_bottomBar.SetOnTabClickListener(this);

			_bottomBar.SetActiveTabColor(Color.Red);
		}
    }
}