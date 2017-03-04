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
    [Register ("GameController")]
    partial class GameController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton backButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView oponentCircleImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView oponentFirstStar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView oponentImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel oponentName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView oponentSecondStar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView oponentThirdStar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton startGameButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView userCircleImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView userFirstStar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView userImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel userName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView userSecondStar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView userThirdStar { get; set; }

        [Action ("BackButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("StartGameButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void StartGameButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (backButton != null) {
                backButton.Dispose ();
                backButton = null;
            }

            if (oponentCircleImage != null) {
                oponentCircleImage.Dispose ();
                oponentCircleImage = null;
            }

            if (oponentFirstStar != null) {
                oponentFirstStar.Dispose ();
                oponentFirstStar = null;
            }

            if (oponentImage != null) {
                oponentImage.Dispose ();
                oponentImage = null;
            }

            if (oponentName != null) {
                oponentName.Dispose ();
                oponentName = null;
            }

            if (oponentSecondStar != null) {
                oponentSecondStar.Dispose ();
                oponentSecondStar = null;
            }

            if (oponentThirdStar != null) {
                oponentThirdStar.Dispose ();
                oponentThirdStar = null;
            }

            if (startGameButton != null) {
                startGameButton.Dispose ();
                startGameButton = null;
            }

            if (userCircleImage != null) {
                userCircleImage.Dispose ();
                userCircleImage = null;
            }

            if (userFirstStar != null) {
                userFirstStar.Dispose ();
                userFirstStar = null;
            }

            if (userImage != null) {
                userImage.Dispose ();
                userImage = null;
            }

            if (userName != null) {
                userName.Dispose ();
                userName = null;
            }

            if (userSecondStar != null) {
                userSecondStar.Dispose ();
                userSecondStar = null;
            }

            if (userThirdStar != null) {
                userThirdStar.Dispose ();
                userThirdStar = null;
            }
        }
    }
}