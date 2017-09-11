using System;
using MvvmCross.Binding.iOS.Views;
using Foundation;
using UIKit;
using CoreGraphics;

namespace Collections.Touch
{
    public partial class KittenCell : MvxTableViewCell
    {
        private const string BindingText = "Name Name;ImageUrl ImageUrl;IsNavigation IsNavigation; Age Age, Converter=AgeToAgeInMonths";

        private MvxImageViewLoader _imageHelper;

        public KittenCell()
            : base(BindingText)
        {
            InitialiseImageHelper();
        }

        public KittenCell(IntPtr handle)
            : base(BindingText, handle)
        {
            InitialiseImageHelper();
        }

        public string Name
        {
            get { return MainLabel.Text; }
            set { MainLabel.Text = value; }
        }

        public string ImageUrl
        {
            get { return _imageHelper.ImageUrl; }
            set { _imageHelper.ImageUrl = value; }
        }

		public string Age
		{
            get { return lblAge.Text; }
            set { lblAge.Text = value; }
		}

        public static float GetCellHeight()
        {
            return 120f;
        }

        //public override void TouchesBegan(NSSet touches, UIEvent evt)
        //{
        //    AnimateToScale(1.2f);
        //}

        //public override void TouchesCancelled(NSSet touches, UIEvent evt)
        //{
        //    AnimateToScale(1.0f);
        //}

        //public override void TouchesEnded(NSSet touches, UIEvent evt)
        //{
        //    AnimateToScale(1.0f);
        //}

        private void AnimateToScale(float scale)
        {
            UIView.BeginAnimations("animateToScale");
            UIView.SetAnimationCurve(UIViewAnimationCurve.EaseIn);
            UIView.SetAnimationDuration(0.5);
            Transform = CGAffineTransform.MakeScale(scale, 1.0f);
            UIView.CommitAnimations();
        }

        private void InitialiseImageHelper()
        {
            _imageHelper = new MvxImageViewLoader(() => KittenImageView);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            imgCheveron.Hidden = !IsNavigation;
        }

        private bool _isNavigation;
        public bool IsNavigation
        {
            get { return _isNavigation; }
            set { _isNavigation = value; }
        }
    }
}