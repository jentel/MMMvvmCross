using Collections.Core.ViewModels.Samples.SmallFixed;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Collections.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public FirstViewModel(IMvxNavigationService navService)
        {
            _service = navService;
        }

        private IMvxNavigationService _service;
        public IMvxNavigationService Service 
        {
            get { return _service; }
            private set 
            {
                _service = value;
            }
        }

		public void ShowMenu()
		{
            ShowViewModel<MainMenuViewModel>();
			ShowViewModel<SmallFixedViewModel>();
		}

		public void ShowHome()
		{
			ShowViewModel<MainMenuViewModel>();
		}

	}
}