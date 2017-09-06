using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.DownloadCache;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform;
using Collections.Core;
using UIKit;
using Collections.Touch.Presenter;
using Collections.Touch.Interfaces;

namespace Collections.Touch
{
    public class Setup
        : MvxIosSetup
    {
		private MvxApplicationDelegate _applicationDelegate;
		private UIWindow _window;

        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
			_applicationDelegate = applicationDelegate;
			_window = window;
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<IAlertService, AlertService>();

            return new Collections.Core.App();
        }

        protected override IMvxIosViewPresenter CreatePresenter()
        {
			var mvxIosViewPresenter = new MvxTabPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
			Mvx.RegisterSingleton<ITabBarPresenterHost>(mvxIosViewPresenter);
			return mvxIosViewPresenter;
        }
    }
}