using System;
using MvvmCross.Droid.Views;

namespace Collections.Droid
{
    public class BaseActivity : MvxActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            ActivityHolder.CurrentActivity = this;
        }
    }
}
