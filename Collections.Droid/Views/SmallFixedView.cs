using Android.App;
using Android.Content.PM;
using Collections.Core.ViewModels.Samples.SmallFixed;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;

namespace Collections.Droid.Views
{
    [Activity(Label = "Small Fixed", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SmallFixedView : MvxFragment<SmallFixedViewModel>
    {
		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			this.EnsureBindingContextIsSet(inflater);
            base.OnCreateView(inflater, container, savedInstanceState);
			return this.BindingInflate(Resource.Layout.Page_FixedView, container, false);
		}
    }
}