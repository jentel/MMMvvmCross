using System;
using Collections.Core;
using UIKit;

namespace Collections.Touch
{
    public class AlertService : IAlertService
    {
        public AlertService()
        {
        }

        public void ShowAlert()
        {
            var alert = new UIAlertView()
            {
                Title = "alert title",
                Message = "this is a simple alert"
            };

            alert.AddButton("Ok");
            alert.Show();

        }
    }
}
