using System;
using Android.App;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace Collections.Droid
{
    public static class ActivityHolder
    {
        private static WeakReference<Activity> _currentActivity;

        public static Activity CurrentActivity
        {
            get
            {
                Activity currentActivity;
                return _currentActivity.TryGetTarget(out currentActivity) ? currentActivity : null;
            }
            set
            {
                _currentActivity = new WeakReference<Activity>(value);
                Mvx.Resolve<IMvxMessenger>().Publish(new CurrentActivityMessage(value, value));
            }
        }
    }
}
