
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Collections.Core;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;
using Android.Transitions;

namespace Collections.Droid
{
    [Activity(Label = "Simple Bio Page")]
    public class SimpleBioPageView : MvxActivity<SimpleBioPageViewModel>
    {
		protected override void OnResume()
		{
			base.OnResume();
			ActivityHolder.CurrentActivity = this;
		}

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            SetContentView(Resource.Layout.Page_SimpleBioView);

            InitializeBindings();
        }

        private void InitializeBindings()
        {
            this.CreateBinding(FindViewById<TextView>(Resource.Id.Name)).To((SimpleBioPageViewModel vm) => vm.Name)
                .WithConversion(new NameToNameWithPunctuationValueConverter(), null).Apply();
            this.CreateBinding(FindViewById<MvxImageView>(Resource.Id.imgKitten)).To((SimpleBioPageViewModel vm) => vm.KittenInformation.ImageUrl).Apply();
            this.CreateBinding(FindViewById<TextView>(Resource.Id.Bio)).To((SimpleBioPageViewModel vm) => vm.KittenInformation.Bio).Apply();
            this.CreateBinding(FindViewById<EditText>(Resource.Id.txtName)).To((SimpleBioPageViewModel vm) => vm.Name).Apply();
        }
   }
}
