using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Collections.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private const int _home = 0;
        private const int _favorite = 1;
		private readonly IMvxNavigationService _navigationService;

        public BaseViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private ICommand _loadVM;
        public ICommand LoadViewModel
        {
            get
            {
                return _loadVM ?? (_loadVM = new MvxCommand<int>(ShowViewModel));
            }
        }

        public void ShowViewModel(int tabSelected)
        {
            switch(tabSelected)
            {
                case _home:
                    _navigationService.Navigate<MainMenuViewModel>();
                    break;
            }
        }

    }
}