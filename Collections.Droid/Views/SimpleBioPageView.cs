
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
using Collections.Core.ValueConverters;

namespace Collections.Droid
{
    [Activity(Label = "Simple Bio Page")]
    public class SimpleBioPageView : BaseActivity
    {

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

            this.CreateBinding(FindViewById<TextView>(Resource.Id.Age)).To((SimpleBioPageViewModel vm) => vm.KittenInformation.Age)
                .WithConversion(new AgeToAgeInMonthsValueConverter(), null).Apply();
        }
   }
}
