using System;
using Android.Support.V4.App;
using Collections.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;

namespace Collections.Droid.Plumbing
{
    public class DroidPresenter : MvxAndroidViewPresenter
    {
		private readonly IMvxViewModelLoader _viewModelLoader;
		private readonly IFragmentTypeLookup _fragmentTypeLookup;
		private FragmentManager _fragmentManager;

		public DroidPresenter(IMvxViewModelLoader viewModelLoader, IFragmentTypeLookup fragmentTypeLookup)
		{
			_fragmentTypeLookup = fragmentTypeLookup;
			_viewModelLoader = viewModelLoader;
		}

		public void RegisterFragmentManager(FragmentManager fragmentManager, MvxFragment initialFragment)
		{
			_fragmentManager = fragmentManager;

			showFragment(initialFragment, false);
		}

		public override void Show(MvxViewModelRequest request)
		{
			Type fragmentType;
			if (_fragmentManager == null || !_fragmentTypeLookup.TryGetFragmentType(request.ViewModelType, out fragmentType))
			{
				base.Show(request);

				return;
			}

			var fragment = (MvxFragment)Activator.CreateInstance(fragmentType);
			fragment.ViewModel = _viewModelLoader.LoadViewModel(request, null);

			showFragment(fragment, true);
		}

		private void showFragment(MvxFragment fragment, bool addToBackStack)
		{
			var transaction = _fragmentManager.BeginTransaction();

			if (addToBackStack)
				transaction.AddToBackStack(fragment.GetType().Name);

			transaction
                .Replace(Resource.Id.content_frame, fragment)
				.Commit();
		}

		public override void Close(IMvxViewModel viewModel)
		{
            var currentFragment = _fragmentManager.FindFragmentById(Resource.Id.content_frame) as MvxFragment;
			if (currentFragment != null && currentFragment.ViewModel == viewModel)
			{
				_fragmentManager.PopBackStackImmediate();

				return;
			}

			base.Close(viewModel);
		}
    }
}
