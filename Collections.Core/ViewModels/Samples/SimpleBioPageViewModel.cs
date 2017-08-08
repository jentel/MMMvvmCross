using System.Threading.Tasks;
using Collections.Core.ViewModels.Samples.ListItems;
using MvvmCross.Core.ViewModels;

namespace Collections.Core
{
    public class SimpleBioPageViewModel : MvxViewModel<Kitten>
    {
        private IAlertService _alertService;

        public SimpleBioPageViewModel(IAlertService alertService)
        {
            _alertService = alertService;
        }

        public override Task Initialize(Kitten parameter)
        {
            KittenInformation = parameter;
            return Task.FromResult(0);
        }
       
        public Kitten KittenInformation { get; private set; }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

             _alertService.ShowAlert("You sure?", "Did you mean to click on this kitten?", "No", "Yes", NoClicked);
        }

        private void NoClicked()
        {
            Close(this);
        }
    }
}
