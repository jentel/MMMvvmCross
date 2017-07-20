// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Collections.Touch
{
    [Register ("SimpleBioPageView")]
    partial class SimpleBioPageView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgKitten { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView tvBioInfo { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgKitten != null) {
                imgKitten.Dispose ();
                imgKitten = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (tvBioInfo != null) {
                tvBioInfo.Dispose ();
                tvBioInfo = null;
            }
        }
    }
}