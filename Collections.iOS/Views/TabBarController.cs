using System;
using Collections.Core.ViewModels;
using Collections.Core.ViewModels.Samples.SmallFixed;
using Collections.Touch.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using UIKit;

namespace Collections.Touch.Views
{
    public partial class TabBarController : MvxTabBarViewController, ITabBarPresenter
    {
        public TabBarController()
        {
            Mvx.Resolve<ITabBarPresenterHost>().TabBarPresenter = this;
            ViewDidLoad();
        }

        private int _createdSoFarCount = 0;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// first time around this will be null, second time it will be OK
			if (ViewModel == null)
				return;

            MainMenuViewModel homeViewModel = (MainMenuViewModel)Mvx.IocConstruct(typeof(MainMenuViewModel));
            SmallFixedViewModel settingsViewModel = (SmallFixedViewModel)Mvx.IocConstruct(typeof(SmallFixedViewModel));
			var viewControllers = new[]
			{
				CreateTabFor("Home", "", homeViewModel),
				CreateTabFor("Settings", "", settingsViewModel)
            };
			ViewControllers = viewControllers;
			CustomizableViewControllers = new UIViewController[] { };
			SelectedViewController = ViewControllers[0];
		}

		private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
		{
			screen.Title = title;
			screen.TabBarItem = new UITabBarItem(title, null, _createdSoFarCount);
			_createdSoFarCount++;
		}

		public new MainMenuViewModel ViewModel
		{
			get { return (MainMenuViewModel)base.ViewModel; }
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

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
        {
            var controller = new UINavigationController();
            controller.NavigationBar.TintColor = UIColor.Black;
            var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
            SetTitleAndTabBarItem(screen, title, imageName);
            controller.PushViewController(screen, false);
            return controller;
        }

        //private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
        //{
            
        //}

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController?.SetNavigationBarHidden(true, false);
        }

       
    }
}

