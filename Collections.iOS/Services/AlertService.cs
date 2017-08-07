using System;
using System.Threading.Tasks;
using Collections.Core;
using MvvmCross.Core.Navigation;
using UIKit;

namespace Collections.Touch
{

    // https://forums.xamarin.com/discussion/8519/yes-no-confirmation-uialertview

    public class AlertService : IAlertService
    {
        

        public void ShowAlert(string title, string message, string positivePromt, string negativePrompt, Action positiveAction, Action negativeAction)
        {


            var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            if (positiveAction == null && !string.IsNullOrWhiteSpace(positivePromt))
            {
                alertController.AddAction(UIAlertAction.Create(positivePromt, UIAlertActionStyle.Default, alert => NullHandler()));
            }
            else if (!string.IsNullOrWhiteSpace(positivePromt))
            {
                alertController.AddAction(UIAlertAction.Create(positivePromt, UIAlertActionStyle.Default, alert => positiveAction()));
            }

            if (negativeAction == null && !string.IsNullOrWhiteSpace(negativePrompt))
            {
                alertController.AddAction(UIAlertAction.Create(negativePrompt, UIAlertActionStyle.Cancel, alert => NullHandler()));
            }
            else if (!string.IsNullOrWhiteSpace(negativePrompt))
            {
                alertController.AddAction(UIAlertAction.Create(negativePrompt, UIAlertActionStyle.Cancel, alert => negativeAction()));
            }
            GetCurrentViewController().PresentViewController(alertController, true, null);
        }

        private void NullHandler()
        {
            // do nothing
        }

        public Task<bool> ShowAlert(string title, string message, string positivePromt, string negativePrompt, int x)
        {
            //var tcs = new TaskCompletionSource<InputResults>();
            //UITextField result = null;

            //var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

            //alert.AddAction(UIAlertAction.Create(positivePromt, UIAlertActionStyle.Default, (UIAlertAction obj) =>
            //{
            //    tcs.SetResult(new InputResults(result.Text, false));
            //}));

            //alert.AddAction(UIAlertAction.Create(negativePrompt, UIAlertActionStyle.Default, (UIAlertAction obj) =>
            //{
            //    tcs.SetResult(new InputResults(string.Empty, true));
            //}));

            //alert.AddTextField((UITextField obj) => { result = obj; });
            //GetCurrentViewController().PresentViewController(alert, true, null);

            //return tcs.Task;

            var tcs = new TaskCompletionSource<bool>();
            var alert = negativePrompt == string.Empty ?
                                                new UIAlertView(title, message, null, positivePromt) :
                                                new UIAlertView(title, message, null, negativePrompt, positivePromt);
            alert.Clicked += (sender, e) => tcs.SetResult(e.ButtonIndex != alert.CancelButtonIndex);


            //var alert = new UIAlertView
            //{

            //    Title = title,
            //    Message = prompt,
            //    CancelButtonIndex = 1
            //};

            //foreach (var button in buttons)
            //{
            //    alert.AddButton(button);
            //}

            //alert.Clicked += (sender, e) => tcs.TrySetResult(e.ButtonIndex != alert.CancelButtonIndex);
            //alert.Show();

            //return tcs.Task;

            //var alert = new UIAlertView()
            //{
            //    Title = title,
            //    Message = message,
            //    CancelButtonIndex = 1
            //};

            //alert.AddButton(negativePrompt);
            //alert.AddButton(positivePromt);

            //alert.Canceled += (sender, e) =>
            //{
            //    alert.Dispose();
            //};

            //alert.Show();



            //var tcs = new TaskCompletionSource<bool>();
            //UITextField result = null;

            //var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

            //alert.AddAction(UIAlertAction.Create(positivePromt, UIAlertActionStyle.Default, (UIAlertAction obj) =>
            //{
            //    tcs.SetResult(false);
            //}));

            //alert.AddAction(UIAlertAction.Create(negativePrompt, UIAlertActionStyle.Default, (UIAlertAction obj) =>
            //{
            //    tcs.SetResult(true);
            //}));

            //alert.AddTextField((UITextField obj) => { result = obj; });
            //GetCurrentViewController().PresentViewController(alert, true, null);     
            return tcs.Task;



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
