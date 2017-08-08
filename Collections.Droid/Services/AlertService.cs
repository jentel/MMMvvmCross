using System;
using Android.App;
using Collections.Core;

namespace Collections.Droid
{
    public class AlertService : IAlertService
    {
        public void ShowAlert(string title, string message, string positivePromt, string negativePrompt, Action positiveAction, Action negativeAction)
        {
            var alert = new AlertDialog.Builder(ActivityHolder.CurrentActivity);

            alert.SetTitle(title);
            alert.SetMessage(message);

            if (!string.IsNullOrWhiteSpace(positivePromt))
            {
                if (positiveAction == null)
                {
                    alert.SetPositiveButton(positivePromt, (sender, e) => NullHandler());
                }
                else
                {
                    alert.SetPositiveButton(positivePromt, (sender, e) => positiveAction());
                }
            }

            if (!string.IsNullOrWhiteSpace(negativePrompt))
            {
                if (negativeAction == null)
                {
                    alert.SetNegativeButton(negativePrompt, (sender, e) => NullHandler());
                }
                else
                {
                    alert.SetNegativeButton(negativePrompt, (sender, e) => negativeAction());
                }
            }

            var dialog = alert.Create();
            if (!dialog.IsShowing)
            {
                dialog.Show();
            }
            else
            {
                dialog.Dismiss();
                dialog.Dispose();
            }
        }

        private void NullHandler()
        {
            // do nothing
        }
    }
}
