using System;
using Collections.Touch.Interfaces;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace Collections.Touch.Presenter
{
    public class MvxTabPresenter : MvxIosViewPresenter, ITabBarPresenterHost
    {
        public MvxTabPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }

        protected override MvvmCross.iOS.Views.MvxNavigationController CreateNavigationController(UIViewController viewController)
        {
			var toReturn = base.CreateNavigationController(viewController);
			toReturn.NavigationBarHidden = true;
			return toReturn;
        }

        public ITabBarPresenter TabBarPresenter { get ; set ; }
    }
}
