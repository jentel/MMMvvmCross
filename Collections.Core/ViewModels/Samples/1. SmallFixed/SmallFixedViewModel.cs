using Collections.Core.ViewModels.Samples.ListItems;
using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Collections.Core.ViewModels.Samples.SmallFixed
{
    public class SmallFixedViewModel : BaseSampleViewModel
    {
        private List<Kitten> _kittens;

        private readonly IMvxNavigationService _navigationService;

        public SmallFixedViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            Kittens = new List<Kitten>(CreateKittens(10));
        }

        public List<Kitten> Kittens
        {
            get { return _kittens; }
            set
            {
                _kittens = value;
                RaisePropertyChanged(() => Kittens);
            }
        }

        private IMvxCommand _showACommand;
        public IMvxCommand ShowACommand
        {
            get
            {
                return _showACommand ?? (_showACommand = new MvxCommand(() =>
                {
                    _navigationService.Navigate<SimpleBioPageViewModel>();
                }));
            }
        }
    }
}