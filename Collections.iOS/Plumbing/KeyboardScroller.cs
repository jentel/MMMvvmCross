using System;
using System.Drawing;
using Foundation;
using UIKit;

namespace Collections.Touch
{
    public class KeyboardScroller
    {
        private UITextField _CurrentTextField;
        private UIView _CurrentView;

        private UIView activeview;                  // stores active view information
        private float scroll_amount = 0.0f;         // amount to scroll 
        private float bottom = 0.0f;                // bottom point
        private float offset = 10.0f;               // extra offset
        private bool moveViewUp = false;            // which direction are we moving

        public KeyboardScroller(UIView currentView, UITextField currentTextField)
        {
            _CurrentView = currentView;
            _CurrentTextField = currentTextField;

            if (_CurrentTextField != null && _CurrentView != null)
            {
                UIToolbar kbToolbar = new UIToolbar(RectangleF.Empty);
                kbToolbar.BarStyle = UIBarStyle.Default;
                kbToolbar.Translucent = true;
                kbToolbar.UserInteractionEnabled = true;
                kbToolbar.SizeToFit();
                UIBarButtonItem btnKBFlexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null);
                UIBarButtonItem btnKBDone = new UIBarButtonItem(UIBarButtonSystemItem.Done, KBToolbarButtonDoneHandler);
                UIBarButtonItem[] btnKBItems = new UIBarButtonItem[] { btnKBFlexibleSpace, btnKBDone };
                kbToolbar.SetItems(btnKBItems, true);

                // Link keyboard to the Text Control
                _CurrentTextField.InputAccessoryView = kbToolbar;
                _CurrentTextField.ClipsToBounds = true;
                _CurrentTextField.LayoutIfNeeded();

                // Keyboard popup
                NSNotificationCenter.DefaultCenter.AddObserver
                (UIKeyboard.DidShowNotification, KeyBoardUpNotification);

                // Keyboard Down
                NSNotificationCenter.DefaultCenter.AddObserver
                (UIKeyboard.WillHideNotification, KeyBoardDownNotification);
            }
        }

        private void KeyBoardUpNotification(NSNotification notification)
        {
        	// get the keyboard size
        	CoreGraphics.CGRect r = UIKeyboard.BoundsFromNotification(notification);

        	// Find what opened the keyboard
            foreach (UIView view in _CurrentView.Subviews)
        	{
        		if (view.IsFirstResponder)
        			activeview = view;
        	}

        	if (activeview != null)
        	{
        		// Bottom of the controller = initial position + height + offset      
        		bottom = ((float)(activeview.Frame.Y + activeview.Frame.Height + offset));

        		// Calculate how far we need to scroll
        		scroll_amount = ((float)(r.Height - (_CurrentView.Frame.Size.Height - bottom)));

        		// Perform the scrolling
        		if (scroll_amount > 0)
        		{
        			moveViewUp = true;
        			ScrollTheView(moveViewUp);
        		}
        		else
        		{
        			moveViewUp = false;
        		}
        	}
        }

        private void KeyBoardDownNotification(NSNotification notification)
        {
        	if (moveViewUp) { ScrollTheView(false); }
        }

        private void ScrollTheView(bool move)
        {
        	// scroll the view up or down
        	UIView.BeginAnimations(string.Empty, System.IntPtr.Zero);
        	UIView.SetAnimationDuration(0.1);

        	CoreGraphics.CGRect frame = _CurrentView.Frame;

        	if (move)
        	{
        		frame.Y -= scroll_amount;
        	}
        	else
        	{
        		frame.Y += scroll_amount;
        		scroll_amount = 0;
        	}

        	_CurrentView.Frame = frame;

        	UIView.CommitAnimations();
        }


        public void KBToolbarButtonDoneHandler(object sender, EventArgs e)
        {
            _CurrentTextField.ResignFirstResponder();
        }

        /* Keyboard Scroller */
        /* http://www.ssekhon.com/blog/2016/10/07/Xamarin-iOS-Keyboard-Coverrs-Text-Field */
    }
}
