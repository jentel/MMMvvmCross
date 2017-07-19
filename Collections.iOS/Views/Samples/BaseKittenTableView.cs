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

            this.AddBindings(new Dictionary<object, string>
                {
                    {source, "ItemsSource Kittens"}
                });

            TableView.Source = source;
            TableView.ReloadData();
        }

        public class TableSource : MvxSimpleTableViewSource
        {
            //private static readonly NSString Identifier = new NSString("KittenCell");
            //private const string BindingText = "SelectedCommand ShowACommand";

            public TableSource(UITableView tableView)
                : base(tableView, "KittenCell", "KittenCell")
            {
            }

            //public TableSource(UITableView tableView)
            //    : base(tableView, UITableViewCellStyle.Default, Identifier, BindingText)
            //{
            //}
        
        }
    }
}