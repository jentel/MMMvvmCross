using Collections.Core.ViewModels.Samples.ListItems;
using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;

namespace Collections.Core.ViewModels.Samples.SmallFixed
{
    public class SmallFixedViewModel : BaseSampleViewModel
    {
        private List<Kitten> _kittens;

        private readonly IMvxNavigationService _navigationService;

        public SmallFixedViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowACommand = new MvxAsyncCommand<SimpleBioPageViewModel.BioInfo>(UpdateBio);

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

        private IMvxCommand<SimpleBioPageViewModel.BioInfo> _showACommand;
        public IMvxCommand<SimpleBioPageViewModel.BioInfo> ShowACommand
        {
            //get
            //{

            //    return _showACommand ?? (_showACommand = new MvxAsyncCommand<SimpleBioPageViewModel.BioInfo>(UpdateBio));

            //return _showACommand ?? (_showACommand =
            //                         new MvxCommand(() =>
            //                         {
            //                         _navigationService.Navigate<SimpleBioPageViewModel, SimpleBioPageViewModel.BioInfo>(new SimpleBioPageViewModel.BioInfo("fluffy", "Likes to bite", Kittens[2].ImageUrl));
            //                         }));

            //}

            get; set;
        }

        private async Task UpdateBio(SimpleBioPageViewModel.BioInfo bio)
        {
            //var result = await _navigationService.Navigate<SimpleBioPageViewModel, SimpleBioPageViewModel.BioInfo>(bio);

             await _navigationService.Navigate<SimpleBioPageViewModel, SimpleBioPageViewModel.BioInfo>(bio);

            //if (result != null)
            //{
            //    // do nothing???
            //}
        }
    }
}