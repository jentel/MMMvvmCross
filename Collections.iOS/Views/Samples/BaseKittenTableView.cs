using System.Collections.Generic;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using Collections.Core.ViewModels.Samples;

namespace Collections.Touch
{
    public class BaseKittenTableView<TViewModel>
        : MvxTableViewController where TViewModel : BaseSampleViewModel
    {
        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new TableSource(TableView)
            {
                UseAnimations = true,
                AddAnimation = UITableViewRowAnimation.Left,
                RemoveAnimation = UITableViewRowAnimation.Right
            };

            this.AddBindings(new Dictionary<object, string>
                {
                    {source, "ItemsSource Kittens"}
                });

            TableView.Source = source;
            TableView.ReloadData();
        }

        public class TableSource : MvxSimpleTableViewSource
        {
            public TableSource(UITableView tableView)
                : base(tableView, "KittenCell", "KittenCell")
            {
            }

            public override System.nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                return 120f;
            }
        }
    }
}