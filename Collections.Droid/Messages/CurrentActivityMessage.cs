using System;
using Android.App;
using MvvmCross.Plugins.Messenger;

namespace Collections.Droid
{
    public class CurrentActivityMessage : MvxMessage
    {
        public Activity CurrentActivity { get; private set; }

        public CurrentActivityMessage(object sender, Activity currentActivity) : base(sender)
        {
            CurrentActivity = currentActivity;
        }
    }
}
