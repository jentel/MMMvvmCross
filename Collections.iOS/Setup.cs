using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.DownloadCache;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform;
using Collections.Core;

namespace Collections.Touch
{
    public class Setup
        : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<IAlertService, AlertService>();

            return new Collections.Core.App();
        }
    }
}