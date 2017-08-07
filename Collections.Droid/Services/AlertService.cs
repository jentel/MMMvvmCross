using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Collections.Core;

namespace Collections.Droid
{
    public class AlertService : IAlertService
    {
        public AlertService()
        {
        }

        public void ShowAlert(string negativePrompt, string positivePromt, string message, string title)
        {

            var tcs = new TaskCompletionSource<bool>();

            var alert = new AlertDialog.Builder(ActivityHolder.CurrentActivity);

            alert.SetTitle(title);
            alert.SetMessage(message);

            alert.SetPositiveButton(positivePromt, (object sender, DialogClickEventArgs e) =>
            {
                tcs.SetResult(true);
            });

            alert.SetNegativeButton(negativePrompt, (sender, e) =>
            {
                tcs.SetResult(false);
            });

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

        public Task<bool> ShowAlert(string title, string prompt, string positivePromt, string negativePrompt, int x)
        {
            throw new NotImplementedException();
        }

        public void ShowAlert(string title, string message, string positivePromt, string negativePrompt, Action positiveAction, Action negativeAction)
        {
            var alert = new AlertDialog.Builder(ActivityHolder.CurrentActivity);

            alert.SetTitle(title);
            alert.SetMessage(message);

            if (positiveAction == null)
            {
                alert.SetPositiveButton(positivePromt, (sender, e) => NullHandler());
            }
            else
            {
                alert.SetPositiveButton(positivePromt, (sender, e) => positiveAction());
            }


            if (negativeAction == null)
            {
                alert.SetPositiveButton(positivePromt, (sender, e) => NullHandler());
            }
            else
            {
                alert.SetNegativeButton(negativePrompt, (sender, e) => negativeAction());
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
