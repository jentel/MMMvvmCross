using System;
using System.Threading.Tasks;
using Collections.Core.ViewModels.Samples.ListItems;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Collections.Core
{
    public class SimpleBioPageViewModel : MvxViewModel<Kitten, Kitten>
    {
        private IAlertService _alertService;
        private readonly IMvxNavigationService _navigationService;

        public SimpleBioPageViewModel(IAlertService alertService, IMvxNavigationService navigationService)
        {
            _alertService = alertService;
            _navigationService = navigationService;
        }

        public override Task Initialize(Kitten parameter)
        {
            if (parameter == null)
                throw new NullReferenceException("Parameter cannot be null");

            KittenInformation = parameter;
            Name = parameter.Name;
            return base.Initialize();
        }

        private Kitten _KittenInfo;
        public Kitten KittenInformation 
        {
            get
            {
                return _KittenInfo;
            }
            set
            {
                if (_KittenInfo != value)
                {
                    _KittenInfo = value;
                    RaisePropertyChanged();
                }
            } 
        }

        private string _Name;
        public string Name
        {
        	get
        	{
                return _Name;
        	}
        	set
            {
                if (_Name != value)
                {
                    _Name = value;                   
                    RaisePropertyChanged();
                }
            }
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

             _alertService.ShowAlert("You sure?", "Did you mean to click on this kitten?", "No", "Yes", NoClicked);
        }

        //public IMvxAsyncCommand NoClicked => new MvxAsyncCommand(async () => await _navigationService.Close(this, KittenInformation));
        

        public override void ViewDisappearing()
        {
            base.ViewDisappearing();

            if (string.Equals(Name, "This kitten does not have a name yet."))
            {
                KittenInformation.Name = string.Empty;
            }
            else if (!string.IsNullOrWhiteSpace(Name))
            {
                KittenInformation.Name = Name;
            }

            Close(KittenInformation);
        }

        private void NoClicked()
        {
            //await _navigationsService.Close(this, KittenInformation);

            //Close(KittenInformation);
            Close(this);
        }
    }
}
