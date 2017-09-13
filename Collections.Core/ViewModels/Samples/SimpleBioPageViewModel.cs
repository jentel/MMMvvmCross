using System;
using System.Threading.Tasks;
using Collections.Core.ViewModels.Samples.ListItems;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Collections.Core
{
    public class SimpleBioPageViewModel : MvxViewModel<Kitten>
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
            if(KittenInformation != null && !KittenInformation.ShouldPopUp)
                _alertService.ShowAlert("You sure?", "Did you mean to click on this kitten?", "No", "Yes", NoClicked);
        }

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
        }

        private void NoClicked()
        {
            Close(this);
        }
    }
}
