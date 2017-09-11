// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Collections.Touch
{
    [Register ("KittenCell")]
    partial class KittenCell
    {
        [Outlet]
        UIKit.UILabel MainLabel { get; set; }


        [Outlet]
        UIKit.UIImageView KittenImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgCheveron { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAge { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgCheveron != null) {
                imgCheveron.Dispose ();
                imgCheveron = null;
            }

            if (KittenImageView != null) {
                KittenImageView.Dispose ();
                KittenImageView = null;
            }

            if (lblAge != null) {
                lblAge.Dispose ();
                lblAge = null;
            }

            if (MainLabel != null) {
                MainLabel.Dispose ();
                MainLabel = null;
            }
        }
    }
}