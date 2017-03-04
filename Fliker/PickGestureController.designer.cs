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

namespace Fliker
{
    [Register ("PickGestureController")]
    partial class PickGestureController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel countdownLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton fingersGestureButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton fistGestureButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton palmGestureButton { get; set; }

        [Action ("FingersGestureButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void FingersGestureButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("FistGestureButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void FistGestureButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("PalmGestureButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PalmGestureButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (countdownLabel != null) {
                countdownLabel.Dispose ();
                countdownLabel = null;
            }

            if (fingersGestureButton != null) {
                fingersGestureButton.Dispose ();
                fingersGestureButton = null;
            }

            if (fistGestureButton != null) {
                fistGestureButton.Dispose ();
                fistGestureButton = null;
            }

            if (palmGestureButton != null) {
                palmGestureButton.Dispose ();
                palmGestureButton = null;
            }
        }
    }
}