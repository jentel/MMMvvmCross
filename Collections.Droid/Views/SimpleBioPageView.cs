
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

namespace Collections.Droid
{
    [Activity(Label = "SimpleBioPageView")]
    public class SimpleBioPageView : MvxActivity
    {

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            SetContentView(Resource.Layout.Page_SimpleBioView);

            InitializeBindings();
        }

        private void InitializeBindings()
        {
            var name = FindViewById<TextView>(Resource.Id.Name);
            this.CreateBinding(name).To((SimpleBioPageViewModel vm) => vm.KittenInformation.Name).Apply();
            this.CreateBinding(FindViewById<ImageView>(Resource.Id.imgKitten)).To((SimpleBioPageViewModel vm) => vm.KittenInformation.ImageUrl);
            this.CreateBinding(FindViewById<TextView>(Resource.Id.Bio)).To((SimpleBioPageViewModel vm) => vm.KittenInformation.Bio);
        }

   }
}
