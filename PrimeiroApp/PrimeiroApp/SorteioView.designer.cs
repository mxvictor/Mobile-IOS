// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace PrimeiroApp
{
    [Register ("SorteioView")]
    partial class SorteioView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonRandom { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TextRandom { get; set; }

        [Action ("ButtonRandom_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonRandom_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ButtonRandom != null) {
                ButtonRandom.Dispose ();
                ButtonRandom = null;
            }

            if (TextRandom != null) {
                TextRandom.Dispose ();
                TextRandom = null;
            }
        }
    }
}