using Collections.Core.ViewModels.Samples.ListItems;
using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Collections.Core.ViewModels.Samples.SmallFixed
{
    public class SmallFixedViewModel : BaseSampleViewModel
    {
        private ObservableCollection<Kitten> _kittens;

        private readonly IMvxNavigationService _navigationService;

        public SmallFixedViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            Kittens = new ObservableCollection<Kitten>(CreateKittens(10));
            foreach (var kitten in Kittens)
            {
                kitten.IsNavigation = true;
            }
        }

        public ObservableCollection<Kitten> Kittens
        {
            get { return _kittens; }
            set
            {
                _kittens = value;
                RaisePropertyChanged();
            }
        }

        private IMvxCommand _showACommand;
        public IMvxCommand ShowACommand
        {
        	get
        	{
                return _showACommand ?? (_showACommand = new MvxCommand<Kitten>(UpdateBio));
            }
        }

        private void UpdateBio(Kitten bio)
        {
            _navigationService.Navigate<SimpleBioPageViewModel, Kitten>(bio);
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();


        }
    }
}