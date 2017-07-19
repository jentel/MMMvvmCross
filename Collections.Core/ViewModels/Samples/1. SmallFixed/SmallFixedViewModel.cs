using Collections.Core.ViewModels.Samples.ListItems;
using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using System.Threading.Tasks;
using System.Diagnostics;
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

        private IMvxAsyncCommand _showACommand;
        public IMvxAsyncCommand ShowACommand
        {
            get
            {
                return _showACommand ?? (_showACommand = new MvxAsyncCommand(async () =>
                {
                    await _navigationService.Navigate<NextViewModel>(null);
                }));
            }
        }

        //public async Task NavigateToNewPage()
        //{
        //   await _navigationService.Navigate<NextViewModel>(null);
        //}

        #region Temporary VM

        public class NextViewModel : BaseSampleViewModel
        {
            public async Task Initialize(object parameter)
            {
                Debug.WriteLine("Made it to next VM");
            }
        }
        #endregion
    }
}