// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PrimeiroApp
{
    [Register ("AtmView")]
    partial class AtmView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ClienteDados { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField testeText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ClienteDados != null) {
                ClienteDados.Dispose ();
                ClienteDados = null;
            }

            if (testeText != null) {
                testeText.Dispose ();
                testeText = null;
            }
        }
    }
}