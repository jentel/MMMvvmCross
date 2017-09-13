using Collections.Core;
using Collections.Core.ValueConverters;
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

            //var button = new UIBarButtonItem();
            //this.NavigationItem.SetLeftBarButtonItem(button, true);
            //this.CreateBinding(button).To<SimpleBioPageViewModel>(vm => vm.BackCommand).Apply();

			var button = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            this.NavigationItem.SetRightBarButtonItem(button, true);
            this.CreateBinding(button).To<SimpleBioPageViewModel>(vm => vm.BackCommand).Apply();

            InitializeImageHelper();

            this.CreateBinding(lblName).To((SimpleBioPageViewModel vm) => vm.Name).WithConversion(new NameToNameWithPunctuationValueConverter(), null).Apply();
            this.CreateBinding(_imageHelper).To((SimpleBioPageViewModel vm) => vm.KittenInformation.ImageUrl).Apply();
            this.CreateBinding(tvBioInfo).To((SimpleBioPageViewModel vm) => vm.KittenInformation.Bio).Apply();
            this.CreateBinding(txtName).To((SimpleBioPageViewModel vm) => vm.Name).Apply();

            this.CreateBinding(lblAge).To((SimpleBioPageViewModel vm) => vm.KittenInformation.Age).WithConversion(new AgeToAgeInMonthsValueConverter(), null).Apply();

            var x = new KeyboardScroller(this.View, txtName);
        }

        private void InitializeImageHelper()
        {
            _imageHelper = new MvxImageViewLoader(() => imgKitten);
        }
    }
}

