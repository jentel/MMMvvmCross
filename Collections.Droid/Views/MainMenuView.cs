using Android.App;
using Android.Content.PM;
using Collections.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;

namespace Collections.Droid.Views
{
    [Activity(Label = "Main Menu", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainMenuView : MvxFragment<MainMenuViewModel>
    {
        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            this.EnsureBindingContextIsSet(inflater);
            var view = this.BindingInflate(Resource.Layout.Page_MainMenuView, container, false);

            return view;
        }
    }
}