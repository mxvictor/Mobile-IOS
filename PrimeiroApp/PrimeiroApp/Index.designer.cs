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
    [Register ("Index")]
    partial class Index
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton buttonTeste { get; set; }

        [Action ("UIButton11427_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton11427_TouchUpInside (UIKit.UIButton sender);

        [Action ("UIButton17647_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton17647_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (buttonTeste != null) {
                buttonTeste.Dispose ();
                buttonTeste = null;
            }
        }
    }
}