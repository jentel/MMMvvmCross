using System.Collections.Generic;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;

namespace Collections.Touch
{
    public class BaseKittenTableView
        : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new TableSource(TableView)
            {
                UseAnimations = true,
                AddAnimation = UITableViewRowAnimation.Left,
                RemoveAnimation = UITableViewRowAnimation.Right
            };

            this.CreateBinding(source).For("ItemsSource").To("Kittens");

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