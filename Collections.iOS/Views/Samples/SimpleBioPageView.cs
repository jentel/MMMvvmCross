using Collections.Core;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;

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

            this.CreateBinding(lblName).To((SimpleBioPageViewModel vm) => vm.Name).WithConversion(new NameToNameWithPunctuationValueConverter(), null).Apply();
            this.CreateBinding(_imageHelper).To((SimpleBioPageViewModel vm) => vm.KittenInformation.ImageUrl).Apply();
            this.CreateBinding(tvBioInfo).To((SimpleBioPageViewModel vm) => vm.KittenInformation.Bio).Apply();
            this.CreateBinding(txtName).To((SimpleBioPageViewModel vm) => vm.Name).Apply();

            var x = new KeyboardScroller(this.View, txtName);
        }

        private void InitializeImageHelper()
        {
            _imageHelper = new MvxImageViewLoader(() => imgKitten);
        }
    }
}

