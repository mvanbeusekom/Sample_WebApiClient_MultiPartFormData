// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WebApiUpload
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton buttonUpload { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView resultTextView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (buttonUpload != null) {
                buttonUpload.Dispose ();
                buttonUpload = null;
            }

            if (resultTextView != null) {
                resultTextView.Dispose ();
                resultTextView = null;
            }
        }
    }
}