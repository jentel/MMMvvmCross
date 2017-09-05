using System.Collections.Generic;
using Collections.Core.ViewModels.Samples.SmallFixed;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Collections.Touch
{
    public class SmallFixedView : BaseKittenTableView<SmallFixedViewModel>
    {
        public SmallFixedView()
        {
            Title = "Small Fixed";
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var source = new TableSource(TableView);
            this.CreateBinding(source).To<SmallFixedViewModel>(vm => vm.Kittens).Apply();
            this.CreateBinding(source).For(s => s.SelectionChangedCommand).To<SmallFixedViewModel>(vm => vm.ShowACommand).Apply();

            TableView.Source = source;
            TableView.ReloadData();
        }
    }
}