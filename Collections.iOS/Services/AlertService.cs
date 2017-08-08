using System;
using Collections.Core;
using UIKit;

namespace Collections.Touch
{
    public class AlertService : IAlertService
    {
        public void ShowAlert(string title, string message, string positivePromt, string negativePrompt, Action positiveAction, Action negativeAction)
        {
            var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

            if (!string.IsNullOrWhiteSpace(positivePromt))
            {
                if (positiveAction == null)
                {
                    alertController.AddAction(UIAlertAction.Create(positivePromt, UIAlertActionStyle.Default, alert => NullHandler()));
                }
                else
                {
                    alertController.AddAction(UIAlertAction.Create(positivePromt, UIAlertActionStyle.Default, alert => positiveAction()));
                }
            }

            if (!string.IsNullOrWhiteSpace(negativePrompt))
            {
                if (negativeAction == null)
                {
                    alertController.AddAction(UIAlertAction.Create(negativePrompt, UIAlertActionStyle.Cancel, alert => NullHandler()));
                }
                else
                {
                    alertController.AddAction(UIAlertAction.Create(negativePrompt, UIAlertActionStyle.Cancel, alert => negativeAction()));
                }
            }
            GetCurrentViewController().PresentViewController(alertController, true, null);
        }

        private void NullHandler()
        {
            // do nothing
        }

        public UIViewController GetCurrentViewController()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;

            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }
            return vc;
        }
    }
}
