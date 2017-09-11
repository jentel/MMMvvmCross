using Android.App;
using Android.Content.PM;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;

namespace Collections.Droid.Views
{
    [Activity(Label = "Small Dynamic", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SmallDynamicView : MvxFragment
    {
		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			this.EnsureBindingContextIsSet(inflater);
			base.OnCreateView(inflater, container, savedInstanceState);
			return this.BindingInflate(Resource.Layout.Page_DynamicView, null);
		}
    }
}