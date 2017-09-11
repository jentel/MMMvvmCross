// <copyright file="Setup.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
//  
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com - Hire me - I'm worth it!

using Android.Content;
using Collections.Core;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Collections.Core.Interfaces;
using Collections.Droid.Services;
using MvvmCross.Droid.Views;
using Collections.Droid.Plumbing;

namespace Collections.Droid
{
    public class Setup
        : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<IAlertService, AlertService>();

            return new App();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();
            MvvmCross.Plugins.DownloadCache.PluginLoader.Instance.EnsureLoaded();
        }

		protected override IMvxAndroidViewPresenter CreateViewPresenter()
		{
			var presenter = Mvx.IocConstruct<DroidPresenter>();

			Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(presenter);

			return presenter;
		}

		protected override void InitializeIoC()
		{
			base.InitializeIoC();

			Mvx.ConstructAndRegisterSingleton<IFragmentTypeLookup, FragmentTypeLookup>();
		}
    }
}