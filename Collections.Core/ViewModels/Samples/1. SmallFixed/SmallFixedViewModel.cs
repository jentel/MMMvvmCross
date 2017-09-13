using Collections.Core.ViewModels.Samples.ListItems;
using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;

namespace Collections.Core.ViewModels.Samples.SmallFixed
{
    public class SmallFixedViewModel : BaseSampleViewModel
    {
        private ObservableCollection<Kitten> _kittens;
        private readonly IMvxNavigationService _navigationService;

        public SmallFixedViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            int i = 0;

            Kittens = new ObservableCollection<Kitten>(CreateKittens(10));
            foreach (var kitten in Kittens)
            {
                kitten.IsNavigation = true;
                kitten.Index = i;
                i++;
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

   //     public override void ViewAppearing()
   //     {
   //         base.ViewAppearing();

			////var kitten = Kittens.SingleOrDefault(x => x.Index == Index);
			////kitten.Name = bio.Name;

			////Kittens.RemoveAt(Index);
        //    //Kittens.Insert(kitten.Index, kitten);
        //}

        private IMvxCommand _showACommand;
        public IMvxCommand ShowACommand
        {
        	get
        	{
                return _showACommand ?? (_showACommand = new MvxCommand<Kitten>(UpdateBio));
            }
        }

        //private int Index;

        private async void UpdateBio(Kitten bio)
        {
            //Index = bio.Index;
            var result = await _navigationService.Navigate<SimpleBioPageViewModel, Kitten, Kitten>(bio);
            // var xy = Kittens.Single(x => x.Index == bio.Index).Name;
            if (result != null)
            {
                var kitten = Kittens.SingleOrDefault(x => x.Index == result.Index);
                kitten.Name = result.Name;

                Kittens.Remove(result);
                Kittens.Insert(kitten.Index, result);
            }
            //else if(bio.Name != xy)
            //{
            //var kitten = Kittens.SingleOrDefault(x => x.Index == bio.Index);
            //kitten.Name = bio.Name;

            //Kittens.RemoveAt(bio.Index);
            //Kittens.Insert(kitten.Index, bio);
            //}
        }

		public IMvxCommand AddKittenCommand
		{
			get 
            { 
                return new MvxCommand(DoAddKitten);
            }
		}

		private void DoAddKitten()
		{
			var kitten = CreateKitten();
            kitten.ShouldPopUp = true;
			kitten.IsNavigation = true;
			Kittens.Insert(0,kitten);

            int i = 0;
			foreach (var kit in Kittens)
			{
				kit.Index = i;
				i++;
			}

            _navigationService.Navigate<SimpleBioPageViewModel, Kitten>(kitten);
		}
    }
}