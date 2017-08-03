using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Collections.Core.ViewModels.Samples.ListItems;
using MvvmCross.Core.ViewModels;

namespace Collections.Core
{
    public class SimpleBioPageViewModel : MvxViewModel<Kitten>
    {
        private IAlertService _alert;

        public SimpleBioPageViewModel(IAlertService alertService)
        {
            _alert = alertService;
        }

        public override Task Initialize(Kitten parameter)
        {
            KittenInformation = parameter;
            return Task.FromResult(0);
        }
       
        public Kitten KittenInformation { get; private set; }


        public override void Appearing()
        {
            base.Appearing();

            _alert.ShowAlert();
        }
    }
}
