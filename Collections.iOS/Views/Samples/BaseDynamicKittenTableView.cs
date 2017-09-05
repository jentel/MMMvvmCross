using System;
using System.Collections.Generic;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace Collections.Touch
{
    public abstract class BaseDynamicKittenTableView
        : MvxTableViewController
    {
        private UIBarButtonItem _rightButton;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _rightButton = new UIBarButtonItem(UIBarButtonSystemItem.Action);
            _rightButton.Clicked += HandleRightButtonClicked;
            NavigationItem.RightBarButtonItem = _rightButton;

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

        private void HandleRightButtonClicked(object sender, EventArgs e)
        {
            var sheet = new UIActionSheet("Actions");
            sheet.AddButton("Add");
            sheet.AddButton("Kill");
            sheet.Clicked += HandleActionSheetButtonClicked;
            sheet.ShowFrom(_rightButton, true);
        }

        private void HandleActionSheetButtonClicked(object sender, UIButtonEventArgs e)
        {
            switch (e.ButtonIndex)
            {
                case 0:
                    AddKittensPressed();
                    break;

                case 1:
                    KillKittensPressed();
                    break;
            }
        }

        protected abstract void AddKittensPressed();

        protected abstract void KillKittensPressed();

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