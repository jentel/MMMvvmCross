using System;
using Collections.Core;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace Collections.Touch
{
    public partial class SimpleBioPageView : MvxViewController
    {
        private MvxImageViewLoader _imageHelper;

        public SimpleBioPageView() : base("SimpleBioPageView", null)
        {
            Title = "Kitten Information";
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            InitializeImageHelper();

            this.CreateBinding(lblName).To((SimpleBioPageViewModel vm) => vm.KittenInformation.Name).Apply();
            this.CreateBinding(_imageHelper).To((SimpleBioPageViewModel vm) => vm.KittenInformation.ImageUrl).Apply();
            this.CreateBinding(tvBioInfo).To((SimpleBioPageViewModel vm) => vm.KittenInformation.Bio).Apply();
        }

        private void InitializeImageHelper()
        {
            _imageHelper = new MvxImageViewLoader(() => imgKitten);
        }
    }
}

