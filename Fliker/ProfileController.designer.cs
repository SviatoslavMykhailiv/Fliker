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
    [Register ("ProfileController")]
    partial class ProfileController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView background { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageCircle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView like { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView likesGiven { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView likesTaken { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton menuButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch modeSwitcher { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel modeTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton searchButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView spinner { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView userImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel userName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView userPanel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (background != null) {
                background.Dispose ();
                background = null;
            }

            if (imageCircle != null) {
                imageCircle.Dispose ();
                imageCircle = null;
            }

            if (like != null) {
                like.Dispose ();
                like = null;
            }

            if (likesGiven != null) {
                likesGiven.Dispose ();
                likesGiven = null;
            }

            if (likesTaken != null) {
                likesTaken.Dispose ();
                likesTaken = null;
            }

            if (menuButton != null) {
                menuButton.Dispose ();
                menuButton = null;
            }

            if (modeSwitcher != null) {
                modeSwitcher.Dispose ();
                modeSwitcher = null;
            }

            if (modeTitle != null) {
                modeTitle.Dispose ();
                modeTitle = null;
            }

            if (searchButton != null) {
                searchButton.Dispose ();
                searchButton = null;
            }

            if (spinner != null) {
                spinner.Dispose ();
                spinner = null;
            }

            if (userImage != null) {
                userImage.Dispose ();
                userImage = null;
            }

            if (userName != null) {
                userName.Dispose ();
                userName = null;
            }

            if (userPanel != null) {
                userPanel.Dispose ();
                userPanel = null;
            }
        }
    }
}