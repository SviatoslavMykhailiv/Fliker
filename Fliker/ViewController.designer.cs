// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Fliker
{
    [Register ("ViewController")]
    partial class SignController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton fbLoginButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton vkLoginButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (fbLoginButton != null) {
                fbLoginButton.Dispose ();
                fbLoginButton = null;
            }

            if (vkLoginButton != null) {
                vkLoginButton.Dispose ();
                vkLoginButton = null;
            }
        }
    }
}