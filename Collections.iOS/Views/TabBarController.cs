using System;
using Collections.Core;
using Collections.Core.ViewModels;
using Collections.Core.ViewModels.Samples;
using Collections.Core.ViewModels.Samples.LargeFixed;
using Collections.Core.ViewModels.Samples.SmallFixed;
using Collections.Touch.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using UIKit;

namespace Collections.Touch.Views
{
    public class TabBarController : MvxTabBarViewController
    {
		public TabBarController()
		{
            Title = "Main Menu";

            Mvx.Resolve<ITabBarPresenterHost>().TabBarPresenter = null;

            ViewDidLoad();
		}

		private int _createdSoFarCount = 0;

		private UIViewController CreateTabFor(string title, UITabBarSystemItem imageName, IMvxViewModel viewModel)
		{
			var controller = new UINavigationController();
			controller.NavigationBar.TintColor = UIColor.Black;
			var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
			SetTitleAndTabBarItem(screen, title, imageName);
			controller.PushViewController(screen, false);
			return controller;
		}

        private void SetTitleAndTabBarItem(UIViewController screen, string title, UITabBarSystemItem imageName)
		{
			screen.Title = title;
            screen.TabBarItem = new UITabBarItem(imageName, _createdSoFarCount);
			_createdSoFarCount++;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			NavigationController?.SetNavigationBarHidden(true, false);
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			if (ViewModel == null)
				return;

			MainMenuViewModel homeViewModel = (MainMenuViewModel)Mvx.IocConstruct(typeof(MainMenuViewModel));
			SmallFixedViewModel favoriteViewModel = (SmallFixedViewModel)Mvx.IocConstruct(typeof(SmallFixedViewModel));

			var viewControllers = new[]
			{
                CreateTabFor("Home", UITabBarSystemItem.MostRecent, homeViewModel),
                CreateTabFor("Favorites", UITabBarSystemItem.Favorites, favoriteViewModel)

			};
			ViewControllers = viewControllers;
			CustomizableViewControllers = new UIViewController[] { };
			SelectedViewController = ViewControllers[0];
        }

        public new FirstViewModel ViewModel
		{
			get { return (FirstViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public bool GoBack()
		{
			var subNavigation = this.SelectedViewController as UINavigationController;
			if (subNavigation == null)
				return false;

			if (subNavigation.ViewControllers.Length <= 1)
				return false;

			subNavigation.PopViewController(true);
			return true;
		}

		public bool ShowView(IMvxIosView view)
		{
			if (TryShowViewInCurrentTab(view))
				return true;

			return false;
		}

		private bool TryShowViewInCurrentTab(IMvxIosView view)
		{
			var navigationController = (UINavigationController)this.SelectedViewController;
			navigationController.PushViewController((UIViewController)view, true);
			return true;
		}
    }
}
